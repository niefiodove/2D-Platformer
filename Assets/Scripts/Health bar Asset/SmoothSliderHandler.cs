using UnityEngine;
using System.Collections;

public class SmoothSliderHandler : BaseSliderHandler
{
    [SerializeField] private float _smoothSpeed = 1f;

    private float _targetValue;
    private Coroutine _smoothCoroutine;

    protected override void Awake()
    {
        base.Awake();
        _targetValue = _slider.value;
    }

    protected override void OnHealthChanged(float health)
    {
        _targetValue = health / _maximumHealth;
        StartSmoothUpdate();
    }

    protected override void InitializeMaximumHealth(float health)
    {
        base.InitializeMaximumHealth(health);
        _targetValue = _slider.value;
        StartSmoothUpdate();
    }

    private void StartSmoothUpdate()
    {
        if (_smoothCoroutine != null)
        {
            StopCoroutine(_smoothCoroutine);
        }
        _smoothCoroutine = StartCoroutine(SmoothUpdateRoutine());
    }

    private IEnumerator SmoothUpdateRoutine()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }

        _smoothCoroutine = null;
    }
}
