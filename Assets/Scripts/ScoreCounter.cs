using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float _score;

    public event Action<float> ValueChanged;

    private void Start()
    {
        _score = 0;
    }

    public void TrackEnemy(Enemy enemy)
    {
        enemy.Killed += AddScore;
    }

    public void UntrackEnemy(Enemy enemy)
    {
        enemy.Killed -= AddScore;
    }

    private void AddScore(Enemy enemy)
    {
        _score++;
        ValueChanged?.Invoke(_score);
        UntrackEnemy(enemy);
    }
}
