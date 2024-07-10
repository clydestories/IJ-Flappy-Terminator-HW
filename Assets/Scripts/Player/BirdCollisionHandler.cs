using System;
using UnityEngine;

[RequireComponent (typeof(Bird), typeof(Collider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    public event Action Collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollidable collidable))
        {
            Collided?.Invoke();
        }
    }
}
