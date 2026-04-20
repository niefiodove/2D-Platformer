using UnityEngine;

public class RewardCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Coin>(out Coin reward))
        {
            Debug.Log(reward.gameObject.name);
            Destroy(reward.gameObject);
        }
    }
}
