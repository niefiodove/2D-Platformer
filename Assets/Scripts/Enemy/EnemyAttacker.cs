using UnityEngine;
using System.Collections;

public class EnemyAttacker : Attacker
{
    protected override void TryCauseDamage(HealthBar healthBar)
    {
        if (_coroutine != null)
        {
            return;
        }

        if (healthBar.gameObject != gameObject &&
            Vector2.Distance(transform.position, healthBar.transform.position) <= _attackRange)
        {
            _healthBar = healthBar;
            _coroutine = StartCoroutine(AttackCoroutine());
        }
    }
    protected override void Attack()
    {
        if (_healthBar == null || _healthBar.gameObject == null)
            return;

        if (Vector2.Distance(transform.position, _healthBar.transform.position) > _attackRange)
            return;

        _animator.TriggerAttack();
        CauseDamage(_healthBar);
    }
}