using UnityEngine;

public class RewardCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Reward>(out Reward reward))
        {
            Debug.Log(reward.gameObject.name);
            Destroy(reward.gameObject);
        }
    }
}
