using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterRotater))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    private Animator _animator;
    private CharacterRotater _characterRotater;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private bool _isRuning = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _characterRotater = GetComponent<CharacterRotater>();
    }

    private void Update()
    {
        if (_input.IsJumping)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            _animator.TriggerJump();
        }

        if (_input.HorizontalInput != 0)
        {
            _characterRotater.FlipSprite(_input.HorizontalInput);
            _isRuning = true;
        }
        _animator.TriggerRun(_isRuning);
        _isRuning = false;
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_input.HorizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}