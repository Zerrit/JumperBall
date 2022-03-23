using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Button restart;
    public Button mainMenu;

    private void Start()
    {
        restart.onClick.AddListener(RestartClick);
        mainMenu.onClick.AddListener(MainMenuClick);
    }

    private void RestartClick()
    {
        GameManager.instance.StartClassic();
        gameObject.SetActive(false);
    }

    private void MainMenuClick()
    {
        gameObject.SetActive(false);
    }
}
