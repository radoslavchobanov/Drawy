using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MainMenu MainMenuPanel;
    public PauseMenu PauseMenuPanel;
    public CompletedLevelPanel CompletedLevelPanel;
    public FailedLevelPanel FailedLevelPanel;
    public GameCompletionPanel GameCompletionPanel;

    public Text TimerText;

    private void Update()
    {
        TimerText.text = GameManager.Singleton.LevelManager.Timer.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Singleton.LevelManager.DrawController.gameObject.SetActive(!GameManager.Singleton.LevelManager.DrawController.gameObject.activeInHierarchy);
            PauseMenuPanel.Toggle();
        }
    }
}
