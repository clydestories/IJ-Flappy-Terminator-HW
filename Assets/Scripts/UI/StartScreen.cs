using UnityEngine;

public class StartScreen : Screen
{
    public void Play()
    {
        Time.timeScale = 1.0f;
        Close();
    }
}
