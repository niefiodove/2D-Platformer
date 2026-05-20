using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _pickupRange = 0.2f;

    public static event Action<PickupItem> pickedUp;

    private void OnEnable()
    {
        Observer.ItemSpotted += TryPickup;
    }

    private void OnDisable()
    {
        Observer.ItemSpotted -= TryPickup;
    }

    private void TryPickup(PickupItem item)
    {
        if (item is PickupItem)
        {
            if (Vector2.Distance(transform.position, item.transform.position) <= _pickupRange)
            {
                if (item is HealthPack healthPack)
                {
                    HealthBar healthBar = GetComponent<HealthBar>();
                    healthBar?.Heal(healthPack.HealthValue);
                }

                pickedUp?.Invoke(item);
            }
        }
    }
}