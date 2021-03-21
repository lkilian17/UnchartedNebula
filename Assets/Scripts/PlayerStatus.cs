using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int vidaInicial = 5;
    public int vidaActual;
    [SerializeField] GameObject[] NacelleTrails;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int dmg)
    {
        vidaActual -= dmg;
        if (vidaActual <= 0)
        {
            DestruirPlayer();
        }
    }

    private void DestruirPlayer()
    {
        gameObject.GetComponent<PlayerWeapon>().DesactivarCañones();
        gameObject.GetComponent<PlayerWeapon>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        foreach (GameObject g in NacelleTrails)
        {
            g.SetActive(false);
        }
    }
}
