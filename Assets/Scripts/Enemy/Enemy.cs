using System;
using UnityEngine;

[RequireComponent (typeof(EnemyShooter))]
public class Enemy : MonoBehaviour, ICollidable
{
    private EnemyShooter _shooter;
    private EnemyPool _pool;

    public event Action<Enemy> Killed;

    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
    }

    private void OnEnable()
    {
        StartCoroutine(_shooter.Shoot());
    }

    public void SetPool(EnemyPool pool)
    {
        _pool = pool;
    }

    public void PassBullets(BulletPool _bullets)
    {
        _shooter.GetBullets(_bullets);
    }

    public void Die()
    {
        Killed?.Invoke(this);
        _pool.Release(this);
    }
}
