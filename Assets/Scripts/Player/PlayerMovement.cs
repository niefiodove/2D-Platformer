using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(CharacterRotater))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    private PlayerAnimator _playerAnimator;
    private CharacterRotater _playerRotater;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private bool _isRuning = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerRotater = GetComponent<CharacterRotater>();
    }

    private void Update()
    {
        if (_input.IsJumping)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            _playerAnimator.TriggerJump();
        }

        if (_input.HorizontalInput != 0)
        {
            _playerRotater.FlipSprite(_input.HorizontalInput);
            _isRuning = true;
        }
        _playerAnimator.TriggerRun(_isRuning);
        _isRuning = false;
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_input.HorizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}