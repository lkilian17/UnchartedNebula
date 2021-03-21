using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRocaWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject proyectilRoca;
    [SerializeField] Transform[] cannons;
    public float shotCD = 1.5f;
    private bool ataqueActivado = false;
    bool shootTime = false;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ataqueActivado)
        {
            if (Time.time >= timer)
            {
                shootTime = true;
                timer = Time.time + shotCD;
            }

            if (shootTime)
            {
                foreach (Transform c in cannons)
                {
                    Instantiate(proyectilRoca, c.position, c.rotation);
                }
                shootTime = false;
            }
        }
    }

    public void ActivarAtaque()
    {
        ataqueActivado = true;
    }
}
