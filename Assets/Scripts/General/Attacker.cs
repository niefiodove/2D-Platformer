using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 0.3f;
    [SerializeField] private float _attackDamage = 3f;

    private PlayerInput _input;
    private Animator _animator;
    private HealthBar _healthBar;
    private bool _canAttack = false;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Observer.EnemySpotted += TryCauseDamage;
    }

    private void OnDisable()
    {
        Observer.EnemySpotted -= TryCauseDamage;
    }

    private void FixedUpdate()
    {
        if (TryGetComponent<Player>(out _))
        {
            if (_input.IsAttack)
            {
                _animator.TriggerAttack();

                if (_canAttack)
                {
                    CauseDamage(_healthBar);
                }
            }
        }
        else
        {
            if (_canAttack)
            {
                CauseDamage(_healthBar);
            }
        }
        _canAttack = false;
    }

    private void CauseDamage(HealthBar healthBar)
    {
        healthBar.TakeDamage(_attackDamage);
        _animator.TriggerAttack();
    }

    private void TryCauseDamage(HealthBar healthBar)
    {
        if (healthBar.gameObject != gameObject && Vector2.Distance(transform.position, healthBar.transform.position) <= _attackRange)
        {
            _canAttack = true;
            _healthBar = healthBar;
        }
    }
}