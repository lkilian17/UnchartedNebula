using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgLaser : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(1);
            print("dano");
        }
    }


    public void DestruirLaser()
    {
        Destroy(gameObject);
    }

    public void EnableCollider()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
