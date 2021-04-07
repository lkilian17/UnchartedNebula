using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per a controlar el menú principal del joc
/// AUTOR:  Helena Martí
/// DATA:   1/4/2021
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: Funcionament dels botons, control dels "sticky buttons" i control de les imatges que apareixen en el dropdown d'audio mode
/// ----------------------------------------------------------------------------------
/// </summary>
/// 

public class ButtonManager : MonoBehaviour
{
    public GameObject inici, exit, options, credits, victory, defeat, pauseMenu, controlsViewer, videoViewer, audioViewer;
    public Button showControlsBTN, showVideoBTN, showAudioBTN;
    public Sprite defaultControlsBTN, pressedControlsBTN, defaultVideoBTN, pressedVideoBTN, defaultAudioBTN, pressedAudioBTN;
    public GameObject headphones, audio20, audio21, audio51;
    public Dropdown audioDropdown;


    // -------- BOTONS MENU PRINCIPAL --------

    public void PlayOnClick()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1; //evita que el joc comenci pausat
    }

    public void CreditsOnClick()
    {
        credits.SetActive(true);
    }

    public void OptionsOnClick()
    {
        options.SetActive(true);
    }

    public void ExitOnClick()
    {
        exit.SetActive(true);
    }


    // -------- BOTONS EXIT --------

    public void ExitYesOnClick()
    {
        Application.Quit();
    }

    public void ExitNoOnClick()
    {
        exit.SetActive(false);
    }


    // -------- BOTONS OPTIONS --------

    public void OptionsReturnOnClick() 
    {
        options.SetActive(false);
    }

    public void StickyButtons(int a)    // funciona tant al menú d'inici com al de pausa
    {
        switch (a)
        {
            case 0:
                showControlsBTN.image.sprite = pressedControlsBTN;
                showVideoBTN.image.sprite = defaultVideoBTN;
                showAudioBTN.image.sprite = defaultAudioBTN;

                controlsViewer.SetActive(true);
                videoViewer.SetActive(false);
                audioViewer.SetActive(false);
                break;
            case 1:
                showControlsBTN.image.sprite = defaultControlsBTN;
                showVideoBTN.image.sprite = pressedVideoBTN;
                showAudioBTN.image.sprite = defaultAudioBTN;

                controlsViewer.SetActive(false);
                videoViewer.SetActive(true);
                audioViewer.SetActive(false);
                break;
            case 2:
                showControlsBTN.image.sprite = defaultControlsBTN;
                showVideoBTN.image.sprite = defaultVideoBTN;
                showAudioBTN.image.sprite = pressedAudioBTN; 
                
                controlsViewer.SetActive(false);
                videoViewer.SetActive(false);
                audioViewer.SetActive(true);
                break;
        }
    }


    // -------- BOTONS CREDITS --------

    public void CreditsReturnOnClick()
    {
        credits.SetActive(false);
    }


    // -------- BOTONS INGAME --------

    public void PauseOnClick()
    {
        Time.timeScale = 0; //pausa el joc

        pauseMenu.SetActive(true);
    }


    // -------- BOTONS PAUSE MENU --------

    public void PauseMenuOptionsOnClick()
    {
        options.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void PauseMenuCreditsOnClick()
    {
        credits.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void PauseMenuMenuOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseMenuReturnOnClick()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1; //torna a activar el temps del joc
    }


    // -------- BOTONS PAUSE CREDITS --------

    public void PauseCreditsReturnOnClick()
    {
        credits.SetActive(false);
        pauseMenu.SetActive(true);
    }


    // -------- BOTONS PAUSE OPTIONS --------

    public void PauseOptionsReturnOnClick()
    {
        options.SetActive(false);
        pauseMenu.SetActive(true);
    }


    // -------- DROPDOWN AUDIO --------

    public void DropdownAudio()
    {
        switch (audioDropdown.value)    // activa o desactiva la imatge corresponent depenent de l'opció seleccionada al dropdown
        {
            case 0:
                headphones.SetActive(true);
                audio20.SetActive(false);
                audio21.SetActive(false);
                audio51.SetActive(false);
                break;
            case 1:
                headphones.SetActive(false);
                audio20.SetActive(true);
                audio21.SetActive(false);
                audio51.SetActive(false);
                break;
            case 2:
                headphones.SetActive(false);
                audio20.SetActive(false);
                audio21.SetActive(true);
                audio51.SetActive(false);
                break;
            case 3:
                headphones.SetActive(false);
                audio20.SetActive(false);
                audio21.SetActive(false);
                audio51.SetActive(true);
                break;
        }
    }

    public void VictoryScreen()
    {
        victory.SetActive(true);
    }

}
