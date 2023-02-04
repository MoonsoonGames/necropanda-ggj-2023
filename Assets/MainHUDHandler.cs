using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHUDHandler : MonoBehaviour
{
    #region Declarables
    private bool ShopOpen;
    private bool GamePaused;

    public GameObject Shop;
    public GameObject HUD;
    public GameObject PauseMenu;

    #endregion

    #region Buttons
    void ShopBTN()
    {

    }

    void PauseBTN()
    {

    }

    #endregion

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        #region Key presses

        #region Shop
        if(Input.GetKeyDown(KeyCode.Tab) && GamePaused == false)
        {
            Shop.SetActive(true);
            HUD.SetActive(false);
            ShopOpen = true;
        }
        #endregion

        #region Pause
        if (Input.GetKeyDown(KeyCode.Escape) && ShopOpen == false)
        {
            HUD.SetActive(false);
            PauseMenu.SetActive(true);
            GamePaused = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && ShopOpen == true)
        {
            ShopOpen = false;
            HUD.SetActive(true);
            Shop.SetActive(false);
        }
        #endregion

        #endregion

        if(GamePaused == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}
