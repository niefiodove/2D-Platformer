using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSliderHandler : MonoBehaviour
{
    [SerializeField] protected HealthBar _health;
    protected Slider _slider;
    protected float _maximumHealth;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected virtual void OnEnable()
    {
            _health.HealthIndicatorChanged += OnHealthChanged;
            _health.HealthIndicatorCreated += InitializeMaximumHealth;
    }

    protected virtual void OnDisable()
    {
            _health.HealthIndicatorChanged -= OnHealthChanged;
            _health.HealthIndicatorCreated -= InitializeMaximumHealth;
    }

    protected abstract void OnHealthChanged(float health);

    protected virtual void InitializeMaximumHealth(float health)
    {
        _maximumHealth = health;
    }
}