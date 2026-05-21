using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public static event Action<PickupItem> ItemSpotted;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PickupItem>(out var item))
        {
            ItemSpotted?.Invoke(item);
        }
    }
}