using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedLevelPanel : LevelPanel
{
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();

        GameManager.Singleton.LevelManager.RestartLevel();
    }
}
