using UnityEngine;

public class LoseScreen : Screen
{
    public void Restart()
    {
        SceneLoader.LoadScene(Scene.Game);
    }
}
