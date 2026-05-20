using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAttacker : Attacker
{
    private PlayerInput _input;
    private bool _isAttacking = false;


    protected override void Awake()
    {
        base.Awake();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_input.IsAttack && _coroutine == null)
        {
            _coroutine = StartCoroutine(AttackCoroutine());
        }
    }

    protected override void TryCauseDamage(HealthBar healthBar)
    {
        if (healthBar.gameObject != gameObject && _isAttacking &&
            Vector2.Distance(transform.position, healthBar.transform.position) <= _attackRange)
        {
            _healthBar = healthBar;
            Attack();
            _isAttacking = false;
        }
    }

    protected override IEnumerator AttackCoroutine()
    {
        yield return null;
        _isAttacking = true;
        _animator.TriggerAttack();

        yield return new WaitForSeconds(_attackSpeed);

        _coroutine = null;
        _isAttacking = false;
    }

    protected override void Attack()
    {
        if (_healthBar == null || _healthBar.gameObject == null)
            return;

        if (Vector2.Distance(transform.position, _healthBar.transform.position) > _attackRange)
            return;

        CauseDamage(_healthBar);
    }
}