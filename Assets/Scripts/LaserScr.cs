using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScr : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enemigo;
    public float speed;
    [SerializeField] bool fuegoBoss = false;
    Rigidbody2D rb;
    [SerializeField] GameObject explosion;
    void Start()
    {
        Destroy(gameObject, 5);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fuegoBoss) { 
        rb.velocity = transform.up*-speed;
        }
        else
        {
        rb.velocity = transform.right * speed;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (!enemigo)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<NaveEnemigaScr>().TakeDamage(1);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (collision.CompareTag("ProyectilPlayer")) //el tag no tiene nada que ver esto mira si colide con el muro al final para destruir los proyectiles al salir
            {
                Destroy(gameObject);
            }
            if (collision.CompareTag("Boss"))
            {
                collision.GetComponent<BossScr>().TakeDamage(1);
                collision.GetComponent<Animator>().SetTrigger("BossHit");
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
                if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerStatus>().TakeDamage(1);

                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }   
    }

}
