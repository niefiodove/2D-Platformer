using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        Player.CoinPickedUp += DestroyCoin;
    }

    private void OnDisable()
    {
        Player.CoinPickedUp -= DestroyCoin;
    }
    public void CreateCoin()
    {
        if (IsCoinMissing())
        {
            Coin reward = Instantiate(_prefab);
            reward.transform.position = transform.position;
        }
    }

    private bool IsCoinMissing()
    {
        bool isCoinMissing = true;

        if (_collider == null)
            return isCoinMissing;

        ContactFilter2D filter = ContactFilter2D.noFilter;

        Collider2D[] results = new Collider2D[10];
        int hitCount = _collider.Overlap(filter, results);

        for (int i = 0; i < hitCount; i++)
        {
            if (results[i].GetComponent<Coin>())
                isCoinMissing = false;
        }

        return isCoinMissing;
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}