using UnityEngine;

[RequireComponent(typeof(UnityEngine.Animator))]
public class Animator : MonoBehaviour
{
    private static readonly int Run = UnityEngine.Animator.StringToHash(Constants.AnimatorRun);
    private static readonly int Jump = UnityEngine.Animator.StringToHash(Constants.AnimatorJump);
    private static readonly int Attack = UnityEngine.Animator.StringToHash(Constants.AnimatorAttack);

    private UnityEngine.Animator _animator;

    private void Start()
    {
        _animator = GetComponent<UnityEngine.Animator>();
    }
    public void TriggerJump()
    {
        _animator.SetTrigger(Jump);
    }
    public void TriggerRun(bool isRuning)
    {
        _animator.SetBool(Run, isRuning);
    }
    public void TriggerAttack()
    {
        _animator.SetTrigger(Attack);
    }
}