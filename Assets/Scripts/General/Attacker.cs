using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] protected float _attackRange = 1f;
    [SerializeField] protected float _attackDamage = 1f;
    [SerializeField] protected float _attackSpeed = 1f;

    protected Coroutine _coroutine;
    protected Animator _animator;
    protected HealthBar _healthBar;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected void OnEnable()
    {
        Observer.EnemySpotted += TryCauseDamage;
    }

    protected void OnDisable()
    {
        Observer.EnemySpotted -= TryCauseDamage;
    }

    protected virtual void TryCauseDamage(HealthBar healthBar)
    {

    }

    protected virtual IEnumerator AttackCoroutine()
    {
        yield return null;

        Attack();

        yield return new WaitForSeconds(_attackSpeed);

        _coroutine = null;
        _healthBar = null;
    }

    protected virtual void Attack()
    {

    }


    protected void CauseDamage(HealthBar healthBar)
    {
        if (healthBar == null)
            return;

        healthBar.TakeDamage(_attackDamage);
    }
}
