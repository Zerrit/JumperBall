using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiController : MonoBehaviour
{
    public MainMenuScreen menuScreen;
    public PauseScreen pauseScreen;
    public VictoryScreen victoryScreen;
    public GameOverScreen gameOverScreen;
    public InGameScreen inGameScreen;
    public Image loadScreen;
    

    private void Start()
    {
        //Подписка на основные события
        GameManager.instance.victoryEvent.AddListener(StartVictoryPanel);
        GameManager.instance.gameOverEvent.AddListener(StartGameOverPanel);


        //Вспомогательные подписки
        menuScreen.playClassic.onClick.AddListener(StartLevel);
        victoryScreen.nextLevel.onClick.AddListener(StartLevel);
        gameOverScreen.restart.onClick.AddListener(StartLevel);

        pauseScreen.resumeLevel.onClick.AddListener(StartInGameUI);

        inGameScreen.pauseButton.onClick.AddListener(StartPause);

        victoryScreen.mainMenu.onClick.AddListener(OpenMenu);
        gameOverScreen.mainMenu.onClick.AddListener(OpenMenu);
        pauseScreen.mainMenu.onClick.AddListener(OpenMenu);
    }

    private void StartLevel()
    {
        StartLoadScreen();
        StartInGameUI();
        RefreshSlider();
    }

    public void StartVictoryPanel ()
    {
        victoryScreen.gameObject.SetActive(true);
        PauseOn();
    }

    public void StartGameOverPanel()
    {
        gameOverScreen.gameObject.SetActive(true);
        PauseOn();
    }

    public void OpenMenu()
    {
        StartLoadScreen();
        inGameScreen.gameObject.SetActive(false);
        menuScreen.gameObject.SetActive(true);
        GameManager.instance.ReturnToMenu();
        PauseOff();
    }

    public void StartInGameUI()
    {
        inGameScreen.gameObject.SetActive(true);
        PauseOff();
    }

    public void RefreshSlider()
    {
        inGameScreen.EnableProgressBar();
    }

    public void StartPause()
    {
        pauseScreen.gameObject.SetActive(true);
        PauseOn();
    }

    public void StartLoadScreen()
    {
        StartCoroutine(LoadScreen());
    }

    public IEnumerator LoadScreen()
    {
        //loadScreen.gameObject.SetActive(true);
        loadScreen.DOFade(1, 0);
        yield return new WaitForSeconds(.7f);
        loadScreen.DOFade(0, .1f);
        //loadScreen.gameObject.SetActive(false); ;
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        Time.timeScale = 1;
    }
}
