using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScr : MonoBehaviour
{
    public int vidaInicial = 45;
    public int vidaActual;
    [SerializeField] GameObject pickupAmmo;
    [SerializeField] GameObject pickupVida;
    Rigidbody2D rb;
    GameObject player;
    float desfase = 0;
    Vector2 moviment = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        desfase = Random.Range(0, 360f);
    }

    private void FixedUpdate()
    {
        CalcularMoviment();
        rb.velocity = moviment;
    }

    private void CalcularMoviment()
    {
        float amplitud = 4, frequencia = 3;
        moviment.x = 0;
        moviment.y = Mathf.Sin(Time.time * frequencia + desfase) * amplitud;
    }

    // Update is called once per frame
    public void TakeDamage(int dmg)
    {
        vidaActual = vidaActual -= 1;

        int rand = Random.Range(1, 100);
        if (rand == 8)
        {
            Instantiate(pickupAmmo, transform.position, transform.rotation);
            print(rand);
        }
        else
        {
            int rand2 = Random.Range(1, 100);
            if (rand2 == 4)
            {
                Instantiate(pickupVida, transform.position, transform.rotation);
            }
            print(rand2 + "**");
        }

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
