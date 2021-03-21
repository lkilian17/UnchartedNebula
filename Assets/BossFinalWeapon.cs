using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinalWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject proyectil;
    private float turn = 1;
    float time = 0;
    float nextTime = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextTime)
        {
            print("dab");
            if (turn == 1) {
            Disparar();
                turn = 2;
            nextTime = Time.time + 3;
            } else if (turn == 2) { 
                turn = 1;
            DispararInverso();
            }
            nextTime = Time.time + 3;
        }
    }

    private void Disparar()
    {
        float delay = 0;
        foreach (Transform child in transform)
        {
            StartCoroutine(SpawnProyectil(delay, child.transform));
            delay += 0.4f;
        }
    }

    private void DispararInverso()
    {
        float delay = 2;
        foreach (Transform child in transform)
        {
            StartCoroutine(SpawnProyectil(delay, child.transform));
            delay -= 0.4f;
        }
    }

    private IEnumerator SpawnProyectil(float delay, Transform punto){
        yield return new WaitForSeconds(delay);
        Instantiate(proyectil, punto.position, punto.rotation);
     }
}
