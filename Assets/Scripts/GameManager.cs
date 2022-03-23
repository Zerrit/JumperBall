using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel;

    public UiController uiController;
    public TowerBuilder towerBuilder;
    public GameObject menuPlane;

    public UnityEvent victoryEvent;
    public UnityEvent gameOverEvent;
    public UnityEvent platformPassing;


    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);

        //LoadProgress();
        currentLevel = 1;

        victoryEvent.AddListener(LevelUp);
    }

    private void LoadProgress()
    {
        if (PlayerPrefs.HasKey("Lvl"))
        {
            currentLevel = PlayerPrefs.GetInt("Lvl");
        }
        else currentLevel = 1;
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("Lvl", currentLevel);
        PlayerPrefs.Save();
    }


    public void StartClassic()
    {
        towerBuilder.ClearTower();
        towerBuilder.BuildLevel(currentLevel);
        menuPlane.SetActive(false);
    }

    public void ReturnToMenu()
    {
        towerBuilder.ClearTower();
        menuPlane.SetActive(true);
    }

    private void LevelUp()
    {
        currentLevel++;
    }

    public int GetPlatformCount()
    {
        if (currentLevel <= 5) return currentLevel + 5;
        else if (currentLevel <= 15) return currentLevel;
        else return currentLevel - 5;
    }

    public int GetPrefubLimit()
    {
        if (currentLevel <= 5) return 4;
        else if (currentLevel <= 15) return 10;
        else if (currentLevel <= 25) return 13;
        else return 15;
    }
}
