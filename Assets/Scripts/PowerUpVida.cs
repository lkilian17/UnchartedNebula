using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moviment = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moviment.x = -5f;
        moviment.y = 0;
    }
    private void FixedUpdate()
    {
        rb.velocity = moviment;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerStatus>().vidaActual < collision.GetComponent<PlayerStatus>().vidaInicial)
            collision.GetComponent<PlayerStatus>().vidaActual += 1;
            Destroy(gameObject);
        }
    }
}
