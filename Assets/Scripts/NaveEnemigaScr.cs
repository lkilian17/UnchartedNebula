using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigaScr : MonoBehaviour
{
    Rigidbody2D rb;
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
    // Start is called before the first frame update
    void Start()
    {
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

    void CalcularMoviment(int tipus)
    {


        switch (tipus)
        {
            case 1:
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2:
                moviment.x = velX / 2;
                moviment.y = 0f;
                break;
            case 3:
                moviment.x = velX;
                moviment.y = velY;
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
        }
    }


}
