using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class VampirismSwitch : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 4f;
    [SerializeField] private float _attackDuration = 6f;
    [SerializeField] private float _attackRadius = 2f;
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private float _damage = 1f;

    private PlayerInput _input;
    private Coroutine _coroutine;
    private CircleCollider2D _triggerZone;
    private Enemy _targetEnemy = null;
    private HashSet<Enemy> _enemys;
    private bool _isAttackReady = true;
    private bool _isAttack = false;

    public static event Action<bool> AttackStateChanged;
    public static event Action<Enemy> TargetSelected;
    public static event Action TargetLose;
    public static event Action<float> StartAttackCooldown;
    public float VampireAttackRadius => _attackRadius;
    public float VampireDamage => _damage;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _triggerZone = GetComponent<CircleCollider2D>();
        _triggerZone.radius = _attackRadius;
        _triggerZone.isTrigger = true;
        _enemys = new HashSet<Enemy>();
    }

    private void Update()
    {
        if (_input.IsVampireAttack)
        {
            if (_isAttackReady)
                _coroutine = StartCoroutine(VampireAttackCoroutine());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var item))
            _enemys.Add(item);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var item))
        {
            if (_enemys.Contains(item))
            {
                if (item == _targetEnemy)
                    TargetSelection();

                _enemys.Remove(item);
            }
        }
    }

    private void TargetSelection()
    {
        if (_enemys != null && _enemys.Count > 0)
        {
            if (_targetEnemy == null)
                _targetEnemy = _enemys.First();

            foreach (var enemy in _enemys)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) <
                    Vector2.Distance(transform.position, _targetEnemy.transform.position))
                    _targetEnemy = enemy;
            }
        }
        else
        {
            _targetEnemy = null;
        }
    }

    private IEnumerator VampireAttackCoroutine()
    {
        _isAttackReady = false;
        _isAttack = true;

        AttackStateChanged?.Invoke(_isAttack);

        int totalTicks = Mathf.RoundToInt(_attackDuration / _damageInterval);

        for (int i = 0; i < totalTicks; i++)
        {
            TargetSelection();

            if (_targetEnemy != null)
                TargetSelected?.Invoke(_targetEnemy);
            else
                TargetLose?.Invoke();

            yield return new WaitForSecondsRealtime(_damageInterval);
        }

        _targetEnemy = null;
        _isAttack = false;

        TargetLose?.Invoke();
        StartAttackCooldown?.Invoke(_attackCooldown);
        AttackStateChanged?.Invoke(_isAttack);

        yield return new WaitForSeconds(_attackCooldown);

        _isAttackReady = true;
    }
}