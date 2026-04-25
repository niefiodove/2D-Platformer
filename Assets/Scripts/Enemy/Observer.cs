using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Observer : MonoBehaviour
{
    [SerializeField] private float _aggroRange = 10f;

    private BoxCollider2D _aggroTrigger;
    private CapsuleCollider2D _mainCollider;
    private float _triggerSizeY;

    public static event Action<Transform> PlayerSpotted;
    public static event Action<Coin> CoinSpotted;
    public static event Action<HealthBar> EnemySpotted;

    private void Awake()
    {
        _mainCollider = GetComponent<CapsuleCollider2D>();
        _triggerSizeY = _mainCollider.size.y;

        AddTrigerZone();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _) && TryGetComponent<Player>(out _) == false)
            PlayerSpotted?.Invoke(collision.gameObject.transform);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (TryGetComponent<Player>(out _))
        {
            if (collision.gameObject.TryGetComponent(out Coin coin))
                CoinSpotted?.Invoke(coin);
        }

        if (collision.gameObject.TryGetComponent(out HealthBar healthBar))
        {
            EnemySpotted?.Invoke(healthBar);
        }
    }

    private void AddTrigerZone()
    {
        _aggroTrigger = gameObject.AddComponent<BoxCollider2D>();
        _aggroTrigger.isTrigger = true;
        _aggroTrigger.size = new Vector2(_aggroRange, _triggerSizeY);
        _aggroTrigger.offset = new Vector2(_aggroTrigger.size.x / 2, _mainCollider.offset.y);
    }
}
