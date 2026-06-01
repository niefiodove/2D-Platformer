using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    [SerializeField] Image _imageOn;
    [SerializeField] Image _imageOff;

    private TMP_Text timerText;
    private float currentTime = 0f;
    private float targetTime = 0f;
    private bool isTimerRunning = false;

    private void Awake()
    {
        timerText = GetComponentInChildren<TMP_Text>();
        if (timerText != null)
            timerText.gameObject.SetActive(false);

        _imageOn.gameObject.SetActive(true);
        _imageOff.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= targetTime)
            {
                currentTime = targetTime;
                UpdateTimerText();
                isTimerRunning = false;
                _imageOff.gameObject.SetActive(false);
                timerText.gameObject.SetActive(false);
            }
            else
            {
                UpdateTimerText();
            }
        }
    }

    private void StartTimer(float finalValue)
    {
        if (finalValue <= 0) 
        {
            return;
        }

        targetTime = finalValue;
        currentTime = 0f;
        isTimerRunning = true;

        if (timerText != null)
        {
            _imageOff.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText == null) return;

        float timeLeft = targetTime - currentTime;
        int seconds = Mathf.CeilToInt(timeLeft);
        timerText.text = string.Format("{0:0}", seconds);
    }

    private void OnEnable()
    {
        VampirismSwitch.StartAttackCooldown += StartTimer;
    }

    private void OnDisable()
    {
        VampirismSwitch.StartAttackCooldown -= StartTimer;
    }
}