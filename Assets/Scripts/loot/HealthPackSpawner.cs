using UnityEngine;
using System.Collections;

public class HealthPackSpawner : PickupItemSpawner
{
    [SerializeField] private float _reapetRate = 0.3f;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnCoroutine());
    }
    protected override bool IsItemMissing()
    {
        bool isItemMissing = true;

        if (_collider == null)
            return isItemMissing;

        ContactFilter2D filter = ContactFilter2D.noFilter;

        Collider2D[] results = new Collider2D[10];
        int hitItem = _collider.Overlap(filter, results);

        return SearchItem(hitItem, results);
    }

    protected override bool SearchItem(int hitItem, Collider2D[] results)
    {
        bool isItemMissing = true;

        for (int i = 0; i < hitItem; i++)
        {
            if (results[i].GetComponent<HealthPack>())
                isItemMissing = false;
        }

        return isItemMissing;
    }

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_reapetRate);

        while (enabled)
        {
            CreateItem();
            yield return wait;
        }
    }
}
