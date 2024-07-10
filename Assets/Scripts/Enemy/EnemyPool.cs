using UnityEngine;

public class EnemyPool : Pool<Enemy>
{
    [SerializeField] private BulletPool _bullets;

    private Vector2 _nextOrigin;

    private void SetOrigin(Vector2 origin)
    {
        _nextOrigin = origin;
    }

    public override Enemy Get(Vector2 origin, Vector2 direcion)
    {
        SetOrigin(origin);
        return ObjectPool.Get();
    }

    protected override void OnGet(Enemy bullet)
    {
        bullet.PassBullets(_bullets);
        bullet.transform.position = _nextOrigin;
        bullet.gameObject.SetActive(true);
    }
}
