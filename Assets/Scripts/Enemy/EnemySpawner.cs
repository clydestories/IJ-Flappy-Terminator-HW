using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _upperPositionY;
    [SerializeField] private float _lowerPositionY;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private ScoreCounter _score;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            float positionY = Random.Range(_lowerPositionY, _upperPositionY);
            Vector2 position = new Vector2(transform.position.x, transform.position.y + positionY);
            Enemy enemy = _pool.Get(position, Vector2.right);
            enemy.SetPool(_pool);
            _score.TrackEnemy(enemy);
        }
    }
}
