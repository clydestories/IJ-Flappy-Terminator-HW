using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(BirdShooter), typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    private BirdCollisionHandler _collisionHandler;
    private BirdMover _mover;
    private BirdShooter _shooter;

    public event Action Died;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _shooter = GetComponent<BirdShooter>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _input.Jumped += OnJump;
        _input.Shot += OnShot;
        _collisionHandler.Collided += Die;
    }

    private void OnDisable()
    {
        _input.Jumped -= OnJump;
        _input.Shot -= OnShot;
        _collisionHandler.Collided -= Die;
    }

    public void Die()
    {
        Died?.Invoke();
    }

    private void OnJump()
    {
        _mover.Jump();
    }

    private void OnShot(Vector2 mouseWorldPosition)
    {
        _shooter.Shoot(mouseWorldPosition);
    }
}
