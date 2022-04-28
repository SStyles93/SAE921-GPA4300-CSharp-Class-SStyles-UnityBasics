using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LockableDoor : MonoBehaviour
{
    [SerializeField] private NavMeshObstacle _obstacle;
    [SerializeField] private bool _locked;

    private void Start()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
    }

    public bool CanOpenTheDoor()
    {
        return !_locked;
    }
    public void OpenTheDoor()
    {
        if (_locked == false)
        {
            //The door is unlocked
            _obstacle.enabled = false;
        }
    }
}
