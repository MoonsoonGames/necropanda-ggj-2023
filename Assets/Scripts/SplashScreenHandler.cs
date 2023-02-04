using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenHandler : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject InfoText;

    public void Play()
    {
        //Load Scene
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
        Buttons.SetActive(true);
        InfoText.SetActive(false);
    }
}
