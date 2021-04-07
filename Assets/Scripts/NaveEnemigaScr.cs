using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigaScr : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject pickUpAmmo;
    [SerializeField] GameObject pickUpVida;
    [SerializeField] GameObject explosion;
    private bool left = false;
    PuntuacionScr puntuacionScr;
    public int vidaInicial = 4;
    public int vidaActual;
    Vector2 moviment = new Vector2();
    [SerializeField] float velX = -5f;
    [SerializeField] int tipusMoviment;
    GameObject player;
    bool chaseTime = false;
    float timer = 0;
    float desfase = 0;
    float velY;
    const int QUANTS_MOVIMENTS = 5;
    [SerializeField] bool abandonaPelea = true;
    private bool destroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
        puntuacionScr = GameObject.FindGameObjectWithTag("GestorPuntuacion").GetComponent<PuntuacionScr>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        velY = Random.Range(-2f, 2f);
        desfase = Random.Range(0, 360f);
        if (tipusMoviment == 0)
        {
            tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            chaseTime = true;
            timer = Time.time + 0.3f;
        }
        if (abandonaPelea)
        {
            CheckAbandonarPelea();
        }
    }

    private void FixedUpdate()
    {
        CalcularMoviment(tipusMoviment);
        rb.velocity = moviment;
    }

    private void DestruirEnemigo()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        int rand = Random.Range(1, 8);
        if (rand == 7)
        {
            Instantiate(pickUpAmmo, transform.position, transform.rotation);
            print(rand);
        }else { 
                int rand2 = Random.Range(1, 7);
                if (rand2 == 4)
                {
                    Instantiate(pickUpVida, transform.position, transform.rotation);
                }
            print(rand2+"**");
            }
        puntuacionScr.puntuacion += 10;
        Destroy(gameObject);
    }

    void CalcularMoviment(int tipus)
    {


        switch (tipus)
        {
            case 1:
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2:
                moviment.x = velX *2f;
                moviment.y = 0f;
                break;
            case 3:
                moviment.x = velX*1.3f;
                moviment.y = 0;
                break;
            case 4:
                float amplitud = 4, frequencia = 3;
                moviment.x = velX;
                moviment.y = Mathf.Sin(Time.time * frequencia + desfase) * amplitud;
                break;
            case 5:
                Vector2 posPlayer = player.transform.position;
                moviment.x = velX;
                if (chaseTime)
                {
                    chaseTime = false;
                    if (posPlayer.y > gameObject.transform.position.y + 2)
                    {
                        moviment.y = +5;
                    }
                    else if (posPlayer.y < gameObject.transform.position.y - 2)
                    {
                        moviment.y = -5;
                    }
                    else
                    {
                        if (posPlayer.y > gameObject.transform.position.y)
                        {
                            moviment.y = Random.Range(0, 3f);
                        }
                        else
                        {
                            moviment.y = Random.Range(0, -3f);
                        }
                    }
                }
                break;
        }
    }

    private void CheckAbandonarPelea()
    {
        if (player.transform.position.x - gameObject.transform.position.x <= -1.5)
        {

        }
        else
        {
            velX = -10f;
            if (!left) {
                left = true;
                puntuacionScr.puntuacion -= 50;
                if (puntuacionScr.puntuacion<0) {
                    puntuacionScr.puntuacion = 0;
                }
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        vidaActual -= dmg;
        if (vidaActual <= 0 && !destroyed){
            destroyed = true;
            DestruirEnemigo();
        }
    }


}
