using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float _health = 10f;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}
