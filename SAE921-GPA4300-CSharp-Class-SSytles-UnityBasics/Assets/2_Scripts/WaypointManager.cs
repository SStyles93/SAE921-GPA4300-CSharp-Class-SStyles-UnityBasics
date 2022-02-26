using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private List<Waypoint> wayPoints = new List<Waypoint>();

    public Waypoint GetNewTarget()
    {
        Waypoint newTarget = wayPoints[Random.Range(0, wayPoints.Count)];

        return newTarget;
    }
}
