using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Run = Animator.StringToHash(PlayerInputConstants.AnimatorRun);
    private static readonly int Jump = Animator.StringToHash(PlayerInputConstants.AnimatorJump);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void TriggerJump()
    {
        _animator.SetTrigger(Jump);
    }
    public void TriggerRun(bool isRuning)
    {
        _animator.SetBool(Run, isRuning);
    }
}