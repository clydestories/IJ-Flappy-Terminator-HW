using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _pool.Release(enemy);
            _scoreCounter.UntrackEnemy(enemy);
        }
    }
}
