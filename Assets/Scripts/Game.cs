using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private StartScreen _startScreen;

    private void OnEnable()
    {
        _bird.Died += Lose;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _bird.Died -= Lose;
    }

    private void Lose()
    {
        Time.timeScale = 0;
        _loseScreen.Open();
    }
}
