using System;

public class CompletedLevelPanel : LevelPanel
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

        GameManager.Singleton.LevelManager.LoadNextLevel();
    }
}
