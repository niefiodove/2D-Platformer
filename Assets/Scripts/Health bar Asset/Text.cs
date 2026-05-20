using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    [SerializeField] private HealthBar _health;

    private float _maximumHelth;
    private TextMeshProUGUI _myText;

    private void Awake()
    {
        _myText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _myText.text = $"{_maximumHelth}/{_maximumHelth}";
    }

    private void OnEnable()
    {
            _health.HealthIndicatorChanged += ChangeText;
            _health.HealthIndicatorCreated += InitializeMaximumHelth;
    }

    private void OnDisable()
    {
            _health.HealthIndicatorChanged -= ChangeText;
            _health.HealthIndicatorCreated -= InitializeMaximumHelth;
    }

    private void ChangeText(float health)
    {
        _myText.text = $"{health}/{_maximumHelth}";
    }

    private void InitializeMaximumHelth(float health)
    {
        _maximumHelth = health;
        _myText.text = $"{health}/{_maximumHelth}";
    }
}