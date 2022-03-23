using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Button resumeLevel;
    public Button mainMenu;


    private void Start()
    {
        resumeLevel.onClick.AddListener(ResumeLevelClick);
        mainMenu.onClick.AddListener(MainMenuClick);
    }


    private void ResumeLevelClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void MainMenuClick()
    {
        gameObject.SetActive(false);
    }
}
