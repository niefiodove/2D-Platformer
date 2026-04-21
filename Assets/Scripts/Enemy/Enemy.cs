using UnityEngine;

[RequireComponent(typeof(Patroller))]
public class Enemy : MonoBehaviour
{
    private Patroller _patroller;

    private void Awake()
    {
        _patroller = GetComponent<Patroller>();
    }

    private void FixedUpdate()
    {
        _patroller.Patrol();
    }
}