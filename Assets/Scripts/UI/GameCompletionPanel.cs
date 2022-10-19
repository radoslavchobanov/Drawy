using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompletionPanel : MonoBehaviour
{
    public Button QuitGameButton;

    private void Awake()
    {
        QuitGameButton.onClick.AddListener(() => GameManager.Singleton.ExitGame());
    }
}
