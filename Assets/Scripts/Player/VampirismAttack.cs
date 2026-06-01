using UnityEngine;

[RequireComponent(typeof(VampirismSwitch))]
public class VampirismAttack : MonoBehaviour
{
    private VampirismSwitch _vampirismSwitch;
    private HealthBar _healthBar;

    private void Awake()
    {
        _vampirismSwitch = GetComponent<VampirismSwitch>();
        _healthBar = GetComponentInParent<HealthBar>();
    }

    private void OnEnable()
    {
        VampirismSwitch.TargetSelected += ApplyAttack;
    }

    private void OnDisable()
    {
        VampirismSwitch.TargetSelected -= ApplyAttack;
    }

    private void ApplyAttack(Enemy enemy)
    {
        _healthBar.Heal(_vampirismSwitch.VampireDamage);
        enemy.gameObject.TryGetComponent<HealthBar>(out var healthBar);
        healthBar.TakeDamage(_vampirismSwitch.VampireDamage);
    }

}
