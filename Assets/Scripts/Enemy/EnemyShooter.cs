using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _shotDelay;
    [SerializeField] private Transform _origin;

    private BulletPool _bullets;

    public void GetBullets(BulletPool bullets)
    {
        _bullets = bullets;
    }

    public IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shotDelay);

        while (enabled)
        {
            yield return wait;
            _bullets.Get(_origin.position, -transform.right).SetHoltility(true);
        }
    }
}
