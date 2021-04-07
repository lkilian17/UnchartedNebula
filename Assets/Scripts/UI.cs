using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per a gestionar les accions relacionades amb la UI
/// AUTOR:  Helena Martí, Mar Masó, Paula Moreta
/// DATA:   04/04/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: Control de la puntuació i la vida
/// ----------------------------------------------------------------------------------
/// </summary>
/// 

public class UI : MonoBehaviour
{
    [SerializeField] Text score;
    PuntuacionScr scrP;
    PlayerStatus scrV;
    public GameObject defeat;
    public Image life01, life02, life03, life04, life05;

    void Start()
    {
        scrP = GameObject.Find("GestorPuntuación").GetComponent<PuntuacionScr>();
        scrV = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    void Update()
    {
        score.text = scrP.puntuacion.ToString();

        switch (scrV.vidaActual)    // defineix el color dels ticks de la barra de vida depenent de la vida restant
        {
            case 0:
                life01.color = new Color32(184, 101, 196, 255);
                life02.color = new Color32(184, 101, 196, 255);
                life03.color = new Color32(184, 101, 196, 255);
                life04.color = new Color32(184, 101, 196, 255);
                life05.color = new Color32(184, 101, 196, 255);
                StartCoroutine(PantallaDefeat());
                break;
            case 1:
                life01.color = new Color32(255, 255, 255, 255);
                life02.color = new Color32(184, 101, 196, 255);
                life03.color = new Color32(184, 101, 196, 255);
                life04.color = new Color32(184, 101, 196, 255);
                life05.color = new Color32(184, 101, 196, 255);
                break;
            case 2:
                life01.color = new Color32(255, 255, 255, 255);
                life02.color = new Color32(255, 255, 255, 255);
                life03.color = new Color32(184, 101, 196, 255);
                life04.color = new Color32(184, 101, 196, 255);
                life05.color = new Color32(184, 101, 196, 255);
                break;
            case 3:
                life01.color = new Color32(255, 255, 255, 255);
                life02.color = new Color32(255, 255, 255, 255);
                life03.color = new Color32(255, 255, 255, 255);
                life04.color = new Color32(184, 101, 196, 255);
                life05.color = new Color32(184, 101, 196, 255);
                break;
            case 4:
                life01.color = new Color32(255, 255, 255, 255);
                life02.color = new Color32(255, 255, 255, 255);
                life03.color = new Color32(255, 255, 255, 255);
                life04.color = new Color32(255, 255, 255, 255);
                life05.color = new Color32(184, 101, 196, 255);
                break;
            case 5:
                life01.color = new Color32(255, 255, 255, 255);
                life02.color = new Color32(255, 255, 255, 255);
                life03.color = new Color32(255, 255, 255, 255);
                life04.color = new Color32(255, 255, 255, 255);
                life05.color = new Color32(255, 255, 255, 255);
                break;
        }
    }


    private IEnumerator PantallaDefeat()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        defeat.SetActive(true); // si et quedes sense vida, es para el joc i et surt la pantalla de loser
    }
}
