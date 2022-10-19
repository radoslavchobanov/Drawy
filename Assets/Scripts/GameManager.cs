using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public LevelManager LevelManager;
    public UIManager UIManager;
    public SoundManager SoundManager;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
    }

    private void Start()
    {
        UIManager.MainMenuPanel.gameObject.SetActive(true);
    }

    private void Update()
    {
    }

    public void StartGame()
    {
        UIManager.MainMenuPanel.gameObject.SetActive(false);
        LevelManager.LoadNextLevel();
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
