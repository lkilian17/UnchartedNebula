using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoFondo : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speedx = -5f;
    Vector2 moviment = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moviment.x = speedx;
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
}
