using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    private bool _isFacingRight = true;
    private int _rotationIndex = 0;
    private int _rightIndex = 0;
    private int _leftIndex = 180;

    public void FlipSprite(float horizontalInput)
    {
        if ((horizontalInput > 0 && !_isFacingRight) || (horizontalInput < 0 && _isFacingRight))
        {
            _isFacingRight = !_isFacingRight;

            if (_isFacingRight)
                _rotationIndex = _rightIndex;
            else
                _rotationIndex = _leftIndex;

            transform.rotation = Quaternion.Euler(0, _rotationIndex, 0);
        }
    }
}
