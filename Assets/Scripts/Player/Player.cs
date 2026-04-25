using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _coinPickupRange = 0.2f;

    public static event Action<Coin> CoinPickedUp;

    private void OnEnable()
    {
        Observer.CoinSpotted += TryPickupCoin;
    }

    private void OnDisable()
    {
        Observer.CoinSpotted -= TryPickupCoin;
    }

    private void TryPickupCoin(Coin coin)
    {
        if(Vector2.Distance(transform.position, coin.transform.position) <= _coinPickupRange)
            CoinPickedUp?.Invoke(coin);
    }

}