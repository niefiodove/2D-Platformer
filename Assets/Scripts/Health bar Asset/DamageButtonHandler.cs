public class DamageButtonHandler : BaseButtonHandler
{
    public override void ButtonClick()
    {
        _health.TakeDamage(_healthDelta);
    }
}
