using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject cannon1;
    [SerializeField] GameObject cannon2;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject[] laseresExtra;
    [SerializeField] float fireRate = 7;
    private float timer = 0;
    private bool cannonsOff = false;
    private float time = 0;
    private float nextTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ETCInput.GetButton("AttackBTN"))
        {
            if (Time.time >= timer) { 
                Instantiate(laser, cannon1.transform.position, cannon1.transform.rotation);
                Instantiate(laser, cannon2.transform.position, cannon2.transform.rotation);
                foreach(GameObject g in laseresExtra)
                {
                    if (g.GetComponent<LaserExtra>().activo)
                    {
                        Instantiate(laser, g.transform.GetChild(0).transform.position, g.transform.GetChild(0).transform.rotation);
                    }
                }
                timer = Time.time + 1f / fireRate;
            }

        }

        time = time += Time.deltaTime;
        if (time >= nextTime)
        {
            if (cannonsOff)
            {
                DesactivarCañones();
            }
        }
    }

    public void ActivarCañones()
    {
        foreach (GameObject g in laseresExtra)
        {
            g.GetComponent<LaserExtra>().activo = true;
            nextTime = Time.time + 15f;
            cannonsOff = true;
        }
    }

    public void DesactivarCañones()
    {
        foreach (GameObject g in laseresExtra)
        {
            g.GetComponent<LaserExtra>().activo = false;
            cannonsOff = false;
        }
    }
}
