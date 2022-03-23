using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public Button nextLevel;
    public Button mainMenu;

    private void Start()
    {
        nextLevel.onClick.AddListener(NextLevelClick);
        mainMenu.onClick.AddListener(MainMenuClick);
    }

    private void NextLevelClick()
    {
        GameManager.instance.StartClassic();
        gameObject.SetActive(false);
    }

    private void MainMenuClick()
    {
        gameObject.SetActive(false);
    }
}
