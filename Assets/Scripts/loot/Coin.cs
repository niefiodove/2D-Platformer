using UnityEngine;

public class Coin : PickupItem
{
    private float _directionIndex = 1f;

    private void Update()
    {
        transform.Rotate(0, _directionIndex * _speed * Time.deltaTime, 0);
    }
}