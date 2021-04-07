using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int vidaInicial = 5;
    public int vidaActual;
    [SerializeField] GameObject[] NacelleTrails;
    [SerializeField] GameObject efectoExplosion;
    [SerializeField] PlayerMovement pm;
    private bool isDead = false;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.07f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1f;
    public bool startBlinking = false;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
    }

    // Update is called once per frame
    void Update()
    {

        if (startBlinking == true && !isDead)
        {
            SpriteBlinkingEffect();
        }
    }

    public void TakeDamage(int dmg)
    {
        vidaActual -= dmg;
        if (vidaActual <= 0)
        {
            isDead = true;
            DestruirPlayer();
        }
        else
        {
            startBlinking = true;
        }
    }

    private void DestruirPlayer()
    {
        gameObject.GetComponent<PlayerWeapon>().DesactivarCañones();
        gameObject.GetComponent<PlayerWeapon>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(efectoExplosion, transform.position, transform.rotation);
        pm.enabled = false;
        foreach (GameObject g in NacelleTrails)
        {
            g.SetActive(false);
        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
}
