using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHUDHandler : MonoBehaviour
{
    #region Declarables
    private bool ShopOpen;
    private bool GamePaused;

    public GameObject Shop;
    public GameObject ShopP1;
    public GameObject ShopP2;
    public GameObject HUD;
    public GameObject PauseMenu;
    public GameObject ConfirmPopup;

    #endregion

    #region Buttons
    public void ShopBTN()
    {
        Shop.SetActive(true);
        HUD.SetActive(false);
        ShopOpen = true;
    }
    public void CloseShop()
    {
        ShopOpen = false;
        HUD.SetActive(true);
        Shop.SetActive(false);
    }
    public void PauseBTN()
    {
        HUD.SetActive(false);
        PauseMenu.SetActive(true);
        GamePaused = true;
    }

    public void Next()
    {
        ShopP1.SetActive(false);
        ShopP2.SetActive(true);
    }

    public void Last()
    {
        ShopP1.SetActive(true);
        ShopP2.SetActive(false);
    }

    public void Quit()
    {
        ConfirmPopup.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void ConfirmQuit()
    {
        Application.Quit();
    }
    public void ConfirmResume()
    {
        ConfirmPopup.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        GamePaused = false;
    }
    #endregion

    void Update()
    {
        #region Key presses

        #region Shop
        if (Input.GetKeyDown(KeyCode.Tab) && GamePaused == false)
        {
            ShopBTN();
        }
        #endregion

        #region Pause
        if (Input.GetKeyDown(KeyCode.Escape) && ShopOpen == false)
        {
            PauseBTN();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && ShopOpen == true)
        {
            ShopOpen = false;
            HUD.SetActive(true);
            Shop.SetActive(false);
        }
        #endregion

        #endregion

        if (GamePaused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
