using UnityEngine;

public class BirdTilter : MonoBehaviour
{
    private const int NegativeToPositivePercentShift = 1;
    private const int PercentNormalizationRate = 2;

    [SerializeField] private float _minTiltAngle;
    [SerializeField] private float _maxTiltAngle;
    [SerializeField] private BirdMover _mover;
    [SerializeField] private Rigidbody2D _rigidbody;


    private void Update()
    {
        if (Time.timeScale != 0)
        {
            float tiltPercent = Mathf.Clamp(_rigidbody.velocity.y, -_mover.JumpForce, _mover.JumpForce) / _mover.JumpForce;
            float tiltCoefficient = (tiltPercent + NegativeToPositivePercentShift) / PercentNormalizationRate;
            float newRotationZ = Mathf.Lerp(_minTiltAngle, _maxTiltAngle, tiltCoefficient);
            transform.rotation = Quaternion.Euler(0, 0, newRotationZ);
        }
        
    }
}
