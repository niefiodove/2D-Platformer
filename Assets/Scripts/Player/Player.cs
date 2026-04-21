using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Coin> CoinPickedUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin reward))
        {
            CoinPickedUp?.Invoke(reward);
        }
    }
}