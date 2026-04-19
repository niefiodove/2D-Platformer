using NUnit.Framework;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private Reward _prefab;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void CreateReward()
    {
        // Проверяем, есть ли уже Reward в коллайдере
        if (IsRewardMissing())
        {
            Reward reward = Instantiate(_prefab);
            reward.transform.position = transform.position;
        }

    }

    private bool IsRewardMissing()
    {
        bool isRewardMissing = true;

        if (_collider == null)
            return isRewardMissing;

        // Получаем все коллайдеры, пересекающиеся с BoxCollider
        ContactFilter2D filter = ContactFilter2D.noFilter;

        Collider2D[] results = new Collider2D[10]; // Массив для результатов
        int hitCount = _collider.Overlap(filter, results);

        // Проверяем, есть ли среди них Reward
        for (int i = 0; i < hitCount; i++)
        {
            if (results[i].GetComponent<Reward>())
            {
                isRewardMissing = false;
            }
        }

        return isRewardMissing;
    }
}