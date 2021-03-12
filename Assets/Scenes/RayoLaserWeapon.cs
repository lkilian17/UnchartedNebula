using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoLaserWeapon : MonoBehaviour
{
    [SerializeField] GameObject rayoLaser;
    [SerializeField] GameObject rayoPoint;
    private bool ataqueActivado = false;
    bool shootTime = false;
    float timer = 2;
    public float shotCD = 3f;
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
                gameObject.GetComponent<Animator>().SetTrigger("EnemigoLaserAttack");
                shootTime = false;
            }
        }
    }
    public void ActivarAtaque()
    {
        ataqueActivado = true;
    }

    public void spawnLaser()
    {
        GameObject laser = Instantiate(rayoLaser, rayoPoint.transform.position, rayoPoint.transform.rotation);
        laser.transform.parent = gameObject.transform;
    }
}
