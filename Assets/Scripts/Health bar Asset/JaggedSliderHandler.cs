public class JaggedSliderHandler : BaseSliderHandler
{
    protected override void OnHealthChanged(float health)
    {
        _slider.value = health / _maximumHealth;
    }
}