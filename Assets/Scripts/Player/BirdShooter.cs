using UnityEngine;

[RequireComponent (typeof(Bird))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private BulletPool _bullets;
    [SerializeField] private Transform _origin;

    public void Shoot(Vector2 target)
    {
        if (Time.timeScale != 0)
        {
            _bullets.Get(_origin.position, target - (Vector2)transform.position).SetHoltility(false);
        }
    }
}
