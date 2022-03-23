using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    public Button playClassic;

    private void Start()
    {
        playClassic.onClick.AddListener(PlayClassicClick);
    }

    private void PlayClassicClick()
    {
        GameManager.instance.StartClassic();
        gameObject.SetActive(false);
    }
}
