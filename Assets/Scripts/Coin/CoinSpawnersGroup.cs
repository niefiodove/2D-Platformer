using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnersGroup : MonoBehaviour
{
    [SerializeField] private float _reapetRate = 2f;
    private List<CoinSpawner> _spawners;

    private void Awake()
    {
        _spawners = new List<CoinSpawner>();

        foreach (Transform child in transform)
            _spawners.Add(child.GetComponent<CoinSpawner>());
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_reapetRate);

        while (enabled)
        {
            int indexSpawner = Random.Range(0, _spawners.Count);
            _spawners[indexSpawner].CreateCoin();
            yield return wait;
        }
    }
}
