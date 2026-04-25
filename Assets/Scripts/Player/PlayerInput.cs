using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsAttack { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Constants.Horizontal);
        IsJumping = Input.GetButtonDown(Constants.Jump);
        IsAttack = Input.GetButtonDown(Constants.Attack);
    }
}