using UnityEngine;

public class BulletPool : Pool<Bullet>
{
    private Vector2 _nextDirection;
    private Vector2 _nextOrigin;

    public override Bullet Get(Vector2 origin, Vector2 direcion)
    {
        SetOrigin(origin);
        SetDirection(direcion);
        return ObjectPool.Get();
    }

    protected override void OnGet(Bullet bullet)
    {
        bullet.transform.position = _nextOrigin;
        bullet.transform.right = _nextDirection;
        bullet.SetPool(this);
        bullet.gameObject.SetActive(true);
    }

    private void SetOrigin(Vector2 origin)
    {
        _nextOrigin = origin;
    }

    private void SetDirection(Vector2 direction)
    {
        _nextDirection = direction;
    }
}
