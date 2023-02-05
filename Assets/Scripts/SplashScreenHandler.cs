using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenHandler : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject InfoText;

    public GameObject MainMenu;
    public GameObject ModeSelection;

    void Start()
    {
        MainMenu.SetActive(true);
        ModeSelection.SetActive(false);
    }
    public void Play()
    {
        MainMenu.SetActive(false);
        ModeSelection.SetActive(true);
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Multiplayer()
    {

    }

    public void Info()
    {
        Buttons.SetActive(false);
        InfoText.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        if (InfoText.activeSelf == true)
        {
            Buttons.SetActive(true);
            InfoText.SetActive(false);
        }
        else if(ModeSelection.activeSelf == true)
        {
            ModeSelection.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
