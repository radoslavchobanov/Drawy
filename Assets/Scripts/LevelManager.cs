using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static event Action OnDrawStateFinish;

    public DrawController DrawController;
    public GameObject LevelContent;

    public List<GameObject> Level = new();

    private int _currentLevel = -1;
    private bool _drawState = false;
    private float _timer = 0f;
    private bool _coinCollected = false;

    private const float DRAW_TIME = 10; // 10s draw time

    public int CurrentLevel => _currentLevel;
    public bool DrawState { get => _drawState; private set => _drawState = value; }
    public int Timer => (int)_timer;
    public bool CoinCollected { get => _coinCollected; private set => _coinCollected = value; }

    public bool IsFinalLevel => CurrentLevel == Level.Count - 1;

    private void Awake()
    {
        BallController.OnScore += OnScore;
        BallController.OnFail += OnFail;
        BallController.OnCoinCollected += OnCoinCollected;
    }

    private void Start()
    {
        _timer = DRAW_TIME;
    }

    private void Update()
    {
        if (DrawState == true)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                FinishDrawState();
            }
        }
    }

    public void LoadNextLevel()
    {
        if (IsFinalLevel)
        {
            OnGameCompleted();
            return;
        }

        LoadLevel(CurrentLevel + 1);
    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevel);
    }

    private void LoadLevel(int levelNumber)
    {
        ClearLevel();

        _currentLevel = levelNumber;

        var level = Instantiate(Level[levelNumber]);
        level.transform.parent = LevelContent.transform;

        StartLevel();
    }

    private void StartLevel()
    {
        _timer = DRAW_TIME;
        CoinCollected = false;
        StartDrawState();
    }

    private void ClearLevel()
    {
        for (int i = 0; i < LevelContent.transform.childCount; ++i)
        {
            GameObject.Destroy(LevelContent.transform.GetChild(i).gameObject);
        }

        DrawController.ClearLineContent();
    }

    private void StartDrawState()
    {
        DrawController.gameObject.SetActive(true);
        DrawState = true;
    }

    private void FinishDrawState()
    {
        DrawController.gameObject.SetActive(false);
        DrawState = false;
        OnDrawStateFinish.Invoke();
    }

    private void OnScore()
    {
        if (CoinCollected == true)
            CompleteLevel();
        else
            FailLevel();
    }

    private void OnFail()
    {
        FailLevel();
    }

    private void OnCoinCollected(GameObject coinObj)
    {
        if (coinObj == null) return;

        CoinCollected = true;
        GameObject.Destroy(coinObj);
        GameManager.Singleton.SoundManager.PlaySound(GameManager.Singleton.SoundManager.CoinPick);
    }

    private void CompleteLevel()
    {
        GameManager.Singleton.UIManager.CompletedLevelPanel.Show();
        GameManager.Singleton.SoundManager.PlaySound(GameManager.Singleton.SoundManager.CompleteSound);
    }

    private void FailLevel()
    {
        GameManager.Singleton.UIManager.FailedLevelPanel.Show();
        GameManager.Singleton.SoundManager.PlaySound(GameManager.Singleton.SoundManager.FailSound);
    }
    
    private void OnGameCompleted()
    {
        GameManager.Singleton.UIManager.GameCompletionPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
