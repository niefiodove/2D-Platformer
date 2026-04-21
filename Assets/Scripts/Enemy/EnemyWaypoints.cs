using UnityEngine;
using System.Collections.Generic;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    public IReadOnlyList<Transform> Waypoints => _waypoints;

#if UNITY_EDITOR
    [ContextMenu("Refresh Waypoints")]
    public void RefreshWaypoints()
    {
        _waypoints = new List<Transform>();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<EnemyWaypoint>(out _))
            {
                _waypoints.Add(child);
            }
        }
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
}