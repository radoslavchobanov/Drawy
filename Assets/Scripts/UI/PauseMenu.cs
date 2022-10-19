using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button UnstuckButton;
    public Button ExitGameButton;

    private void Awake()
    {
        UnstuckButton.onClick.AddListener(OnUnstuckButtonClicked);
        ExitGameButton.onClick.AddListener(GameManager.Singleton.ExitGame);
    }

    private void OnUnstuckButtonClicked()
    {
        GameManager.Singleton.LevelManager.RestartLevel();
        Toggle();
    }

    public void Toggle()
    {            
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        GameManager.Singleton.SoundManager.TogglePause();
        this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
    }
}
