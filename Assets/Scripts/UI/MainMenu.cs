using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject RulesPanel;

    public Button StartGameButton;
    public Button RulesButton;
    public Button ExitGameButton;

    public Button BackButton;

    private void Awake()
    {
        StartGameButton.onClick.AddListener(GameManager.Singleton.StartGame);
        RulesButton.onClick.AddListener(ShowRules);
        ExitGameButton.onClick.AddListener(GameManager.Singleton.ExitGame);

        BackButton.onClick.AddListener(ShowMainPanel);
    }

    private void ShowRules()
    {
        MainPanel.SetActive(false);
        RulesPanel.SetActive(true);
    }
    
    private void ShowMainPanel()
    {
        RulesPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
