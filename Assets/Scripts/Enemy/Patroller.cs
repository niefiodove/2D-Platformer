using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private List<Transform> _patrolPoints;

    private Rigidbody2D _rigidbody;
    private int _currentPointIndex = 0;
    private int _rotationIndex = 0;
    private int _rightIndex = 0;
    private int _leftIndex = 180;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_patrolPoints != null && _patrolPoints.Count > 0)
        {
            transform.position = _patrolPoints[0].position;
            _currentPointIndex = 1;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_patrolPoints == null || _patrolPoints.Count < 2)
            return;

        Transform targetPoint = _patrolPoints[_currentPointIndex];

        float directionX = Mathf.Sign(targetPoint.position.x - transform.position.x);

        _rigidbody.linearVelocity = new Vector2(directionX * _moveSpeed, _rigidbody.linearVelocity.y);

        if (Mathf.Abs(targetPoint.position.x - transform.position.x) < 0.05f)
        {
            MoveToNextPoint();
        }

        if (directionX != 0)
        {
            if (directionX > 0)
                _rotationIndex = _rightIndex;
            else
                _rotationIndex = _leftIndex;

            FlipSprite(_rotationIndex);
        }
    }

    private void MoveToNextPoint()
    {
        _currentPointIndex++;
        if (_currentPointIndex >= _patrolPoints.Count)
            _currentPointIndex = 0;
    }

    private void FlipSprite(int rotationIndex)
    {
        transform.rotation = Quaternion.Euler(0, _rotationIndex, 0);
    }
}