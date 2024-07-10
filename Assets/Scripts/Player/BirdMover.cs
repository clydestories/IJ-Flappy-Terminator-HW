using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(Bird))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public float JumpForce => _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _jumpForce);
    }
}
