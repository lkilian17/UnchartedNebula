using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAtaquesEnemigos : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<NaveEnemigaWeapon>()) { 
                collision.GetComponent<NaveEnemigaWeapon>().ActivarAtaque();
            }else if (collision.GetComponent<RayoLaserWeapon>()){
                collision.GetComponent<RayoLaserWeapon>().ActivarAtaque();
            }
        }
    }
}
