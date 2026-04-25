using UnityEngine;

[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Stalker))]
public class Enemy : MonoBehaviour
{
    private Patroller _patroller;
    private Stalker _stalker;
    private Transform _player;
    private bool _canSeePlayer = false;

    private void Awake()
    {
        _patroller = GetComponent<Patroller>();
        _stalker = GetComponent<Stalker>();
    }

    private void OnEnable()
    {
        Observer.PlayerSpotted += SeePlayer;
    }

    private void OnDisable()
    {
        Observer.PlayerSpotted -= SeePlayer;
    }

    private void FixedUpdate()
    {
        if (_canSeePlayer)
            _stalker.Chase(_player);
        else
            _patroller.Patrol();
    }

    private void SeePlayer(Transform transform)
    {
        _player = transform;
        _canSeePlayer = true;
        gameObject.TryGetComponent(out Observer observer);
    }
}