using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool IsJumping { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(PlayerInputConstants.Horizontal);
        IsJumping = Input.GetButtonDown(PlayerInputConstants.Jump);
    }
}
