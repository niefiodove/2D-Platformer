using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    private float _directionIndex = 1f;

    private void Update()
    {
        transform.Rotate(0, _directionIndex * _rotationSpeed * Time.deltaTime, 0);
    }
}