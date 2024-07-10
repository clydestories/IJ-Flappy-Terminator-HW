using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}

public enum Scene
{
    Game
}
