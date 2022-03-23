using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreen : MonoBehaviour
{
    public Button pauseButton;

    public Slider progressSlider;
    public Text currentLevel;
    public Text nextLevel;


    private void Start()
    {
        GameManager.instance.platformPassing.AddListener(ProgressBarIncrease);
        GameManager.instance.victoryEvent.AddListener(EnableProgressBar);
        GameManager.instance.gameOverEvent.AddListener(EnableProgressBar);

        pauseButton.onClick.AddListener(PauseButtonClick);
    }


    public void PauseButtonClick()
    {
        gameObject.SetActive(false);
    }

    public void EnableProgressBar()
    {
        currentLevel.text = GameManager.instance.currentLevel.ToString();
        nextLevel.text = (GameManager.instance.currentLevel + 1).ToString();
        progressSlider.value = 0;
    }


    public void DisableProgressBar()
    {
        //gameController.SliderOn();
    }


    public void ProgressBarIncrease()
    {
        Debug.Log(GameManager.instance.GetPlatformCount() + 1);
        progressSlider.value += (1f / (GameManager.instance.GetPlatformCount() + 1));
    }
}
