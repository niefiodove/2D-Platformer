using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isRuning = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    public void Move(float directionX, Transform targetPoint)
    {
        _rigidbody.linearVelocity = new Vector2(directionX * _moveSpeed, _rigidbody.linearVelocity.y);
        _isRuning = true;
        _animator.TriggerRun(true);
    }
}
