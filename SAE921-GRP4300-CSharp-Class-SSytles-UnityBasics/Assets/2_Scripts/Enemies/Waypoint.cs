using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform _wayPointTransform;

    public Transform WayPointTransform { get => _wayPointTransform; set => _wayPointTransform = value; }

    public void Awake()
    {
        WayPointTransform = GetComponent<Transform>();
    }
}
