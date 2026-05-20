public class HealButtonHandler : BaseButtonHandler
{
    public override void ButtonClick()
    {
        _health.Heal(_healthDelta);
    }
}
