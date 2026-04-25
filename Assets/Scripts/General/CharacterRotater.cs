using UnityEngine;

public class CharacterRotater : MonoBehaviour
{
    private bool _isFacingRight = true;
    private int _currentRotationAngle = 0;
    private int _rightAngle = 0;
    private int _leftAngle = 180;

    public bool IsFacingRight => _isFacingRight;

    public void FlipSprite(float horizontalInput)
    {
        if ((horizontalInput > 0 && !_isFacingRight) || (horizontalInput < 0 && _isFacingRight))
        {
            _isFacingRight = !_isFacingRight;

            if (_isFacingRight)
                _currentRotationAngle = _rightAngle;
            else
                _currentRotationAngle = _leftAngle;

            transform.rotation = Quaternion.Euler(0, _currentRotationAngle, 0);
        }
    }
}