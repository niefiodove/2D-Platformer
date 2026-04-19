using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f; // Скорость вращения (градусов в секунду)
    private float _directionIndex = 1f; // По часовой стрелке или против

    void Update()
    {
        transform.Rotate(0, _directionIndex * _rotationSpeed * Time.deltaTime, 0);
    }
}
