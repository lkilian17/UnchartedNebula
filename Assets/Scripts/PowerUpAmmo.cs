using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAmmo : MonoBehaviour
{
    [SerializeField] AudioClip recogerPickup;
    PlayerWeapon weapon;
    Rigidbody2D rb;
    Vector2 moviment = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        moviment.x = -5f;
        moviment.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moviment;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            weapon.ActivarCañones();
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(recogerPickup, Camera.main.transform.position);
        }
    }
}
