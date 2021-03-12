using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigaWeapon : MonoBehaviour
{
    [SerializeField] Transform[] cannons;
    [SerializeField] GameObject proyectil;
    [SerializeField] int doubleShot = 0;
    private bool ataqueActivado = false;
    private int shotCount = 0;
    public float shotCD = 1.5f;
    private bool extraShot = false;
    bool shootTime = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ataqueActivado) { 
            if (Time.time >= timer)
            {
                shootTime = true;
                timer = Time.time + shotCD;
            }

            if (shootTime)
            {
                foreach (Transform c in cannons){ 
                Instantiate(proyectil, c.position, c.rotation);
                }
                if (!extraShot) { 
                    shotCount++;
                }
                else
                {
                    extraShot = false;
                }

                if (shotCount == doubleShot)
                {
                    shotCount = 0;
                    timer -= shotCD / 1.4f;
                    extraShot = true;
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
