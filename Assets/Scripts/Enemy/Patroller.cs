using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(CharacterRotater))]
public class Patroller : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private EnemyWaypoints _enemyWaypoints;

    private Mover _mover;
    private CharacterRotater _playerRotater;
    private int _currentPointIndex = 0;
    private float _minimumTurningDistance = 0.05f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _playerRotater = GetComponent<CharacterRotater>();
    }
    private void Start()
    {
        if (_patrolPoints != null && _patrolPoints.Count > 0)
        {
            transform.position = _patrolPoints[0].position;
            _currentPointIndex = 1;
        }
    }

    public void Patrol()
    {
        if (_patrolPoints == null || _patrolPoints.Count < 2)
            return;

        Transform targetPoint = _patrolPoints[_currentPointIndex];

        float directionX = Mathf.Sign(targetPoint.position.x - transform.position.x);
        _mover.Move(directionX, targetPoint);

        if (Mathf.Abs(targetPoint.position.x - transform.position.x) < _minimumTurningDistance)
        {
            MoveToNextPoint();
        }
            _playerRotater.FlipSprite(directionX);
    }

    private void MoveToNextPoint()
    {
        _currentPointIndex = ++_currentPointIndex % _patrolPoints.Count;
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _enemyWaypoints.RefreshWaypoints();

        if (_enemyWaypoints.Waypoints.Count > 0)
        {
            for (int i = 0; i < _patrolPoints.Count; i++)
            {
                _patrolPoints[i] = _enemyWaypoints.Waypoints[Random.Range(0, _enemyWaypoints.Waypoints.Count)];
            }
        }
    }
#endif
}