using System;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public static event Action<HealthBar> EnemySpotted;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthBar>(out var healthBar))
        {
            EnemySpotted?.Invoke(healthBar);
        }
    }
}