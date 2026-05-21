using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private float _pickupRange = 0.2f;

    public static event Action<PickupItem> pickedUp;

    private void OnEnable()
    {
        ItemDetector.ItemSpotted += TryPickup;
    }

    private void OnDisable()
    {
        ItemDetector.ItemSpotted -= TryPickup;
    }

    private void TryPickup(PickupItem item)
    {
        if (Vector2.Distance(transform.position, item.transform.position) <= _pickupRange)
        {
            if (item is HealthPack healthPack)
            {
                HealthBar healthBar = GetComponent<HealthBar>();
                healthBar?.Heal(healthPack.HealthValue);
            }

            if(item is Coin coin)
            {
                _coinCounter.AddCoin();
            }

            pickedUp?.Invoke(item);
        }
    }
}