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
        GamePaused = !GamePaused;

        HUD.SetActive(!GamePaused);
        PauseMenu.SetActive(GamePaused);
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

    #endregion

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (ShopOpen == true)
            {
                ShopOpen = false;
                AISpawner.instance.ShopClosed();
                HUD.SetActive(true);
                Shop.SetActive(false);
            }
            else if (GamePaused == true)
            {
                GamePaused = false;
                HUD.SetActive(true);
                PauseMenu.SetActive(false);
            }
            else
            {
                PauseBTN();
            }
        }

        if(GamePaused == true)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}
