using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _health = 10f;
    private float _maximumHealth;
    private float _minimumHealth = 0f;

    public event Action<float> HealthIndicatorChanged;
    public event Action<float> HealthIndicatorCreated;

    private void Awake()
    {
        _maximumHealth = _health;
    }

    private void Start()
    {
        HealthIndicatorCreated?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        _health -= damage;
        BoundaryCheck();
        HealthIndicatorChanged?.Invoke(_health);
    }

    public void Heal(float healAmount)
    {
        if (healAmount <= 0)
            return;

        _health += healAmount;
        BoundaryCheck();
        HealthIndicatorChanged?.Invoke(_health);
    }

    private void BoundaryCheck()
    {
        _health = Math.Clamp(_health, _minimumHealth, _maximumHealth);
    }
}