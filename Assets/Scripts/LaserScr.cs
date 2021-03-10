using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScr : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enemigo;
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        Destroy(gameObject, 5);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up*-speed;    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (!enemigo)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<NaveEnemigaScr>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
        else
        {
                if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerStatus>().TakeDamage(1);
                Destroy(gameObject);
            }
        }   
    }
}
