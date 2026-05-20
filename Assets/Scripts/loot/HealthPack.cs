using UnityEngine;

public class HealthPack : PickupItem
{
    [SerializeField] private float _height = 0.1f;
    [SerializeField] private float _healthValue = 5f;
    private Vector3 _startPosition;

    public float HealthValue => _healthValue;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * _speed) * _height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}