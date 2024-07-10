using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;

    private Rigidbody2D _rigidbody;
    private BulletPool _pool;
    private bool _isHostile;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * _speed * Time.fixedDeltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_isHostile == false)
            {
                enemy.Die();
            }
        }
        else if (collision.gameObject.TryGetComponent(out Bird player))
        {
            if (_isHostile)
            {
                player.Die();
            }
        }

        Disappear();
    }

    public void SetPool(BulletPool pool)
    {
        _pool = pool;
    }

    public void SetHoltility(bool isHostile)
    {
        _isHostile = isHostile;
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(_lifetime);
        Disappear();
    }

    private void Disappear()
    {
        _pool.Release(this);
    }
}
