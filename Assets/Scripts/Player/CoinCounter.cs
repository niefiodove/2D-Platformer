using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private float _amount = 0;
    public float Amount => _amount;

    private TextMeshProUGUI _myText;

    private void Awake()
    {
        _myText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _myText.text = _amount.ToString();
    }

    public void AddCoin()
    {
        _amount++;
        _myText.text = _amount.ToString();
    }
}
