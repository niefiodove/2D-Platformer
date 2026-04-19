using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    private PlayerAnimator _playerAnimator;
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;
    private bool _isRuning = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        // Прыжок по пробелу
        if (_input.IsJumping)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
            _playerAnimator.TriggerJump();
        }

        if (_input.HorizontalInput != 0)
        {
            FlipSprite(_input.HorizontalInput);
            _isRuning = true;
        }
        _playerAnimator.TriggerRun(_isRuning);
        _isRuning = false;
    }

    private void FixedUpdate()
    {
        // Движение (физика должна обновляться в FixedUpdate)
        _rigidbody.linearVelocity = new Vector2(_input.HorizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void FlipSprite(float horizontalInput)
    {
        // Если движемся вправо (input > 0) и смотрим влево, или наоборот
        if ((horizontalInput > 0 && !_isFacingRight) || (horizontalInput < 0 && _isFacingRight))
        {
            _isFacingRight = !_isFacingRight;

            // Меняем масштаб по оси X
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
