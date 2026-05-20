using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PickupItemSpawner : MonoBehaviour
{
    [SerializeField] private PickupItem _prefab;
    protected BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        Player.pickedUp += DestroyItem;
    }

    private void OnDisable()
    {
        Player.pickedUp -= DestroyItem;
    }

    protected void DestroyItem(PickupItem item)
    {
        Destroy(item.gameObject);
    }

    public void CreateItem()
    {
        if (IsItemMissing())
        {
            PickupItem reward = Instantiate(_prefab);
            reward.transform.position = transform.position;
        }
    }

    protected virtual bool IsItemMissing()
    {
        bool isItemMissing = true;

        if (_collider == null)
            return isItemMissing;

        ContactFilter2D filter = ContactFilter2D.noFilter;

        Collider2D[] results = new Collider2D[10];
        int hitItem = _collider.Overlap(filter, results);

        return SearchItem(hitItem, results);
    }

    protected virtual bool SearchItem(int hitItem, Collider2D[] results)
    {
        bool isItemMissing = true;

        for (int i = 0; i < hitItem; i++)
        {
            if (results[i].GetComponent<PickupItem>())
                isItemMissing = false;
        }

        return isItemMissing;
    }
}
