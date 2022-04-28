using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    private BTTree _robberTree;
    private BTNode _goToFrontDoor;
    private BTNode _goToBackDoor;
    private BTNode _goToDiamond;
    private BTNode _goToVan;
    private BTSequence _steelAction;
    private BTSelector _selectADoor;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject _diamond;
    [SerializeField] private LockableDoor _frontDoor;
    [SerializeField] private LockableDoor _backDoor;
    [SerializeField] private GameObject _van;
    [SerializeField] private float DetectionRange;

    void Start()
    {
        if (TryGetComponent<NavMeshAgent>(out _navMeshAgent) == false)
            Debug.Log("No nav mesh agent !!!");

        _robberTree = new BTTree("Root");
        _goToFrontDoor = new BTLeaf("Got to the front door", goToFrontDoorBehaviour);
        _goToBackDoor = new BTLeaf("Got to the back dook", goToBackDoorBehaviour);
        _goToDiamond = new BTLeaf("Go To Diamond", goToDiamondBehaviour);
        _goToVan = new BTLeaf("Go To Van", goToVanBehaviour);
        _steelAction = new BTSequence("Steel The Diamond");
        _selectADoor = new BTSelector("Select a Door");

        _selectADoor.AddChild(_goToFrontDoor);
        _selectADoor.AddChild(_goToBackDoor);

        _steelAction.AddChild(_selectADoor);
        _steelAction.AddChild(_goToDiamond);
        _steelAction.AddChild(_goToVan);

        _robberTree.AddChild(_steelAction);

        _robberTree.printTree();
    }

    private void Update()
    {
        Debug.Log(_robberTree.Process());
    }

    private BTNode.NodeStatus GoToDestination(GameObject destination)
    {
        if (Vector3.Distance(destination.transform.position, transform.position) < DetectionRange)
        {
            return BTNode.NodeStatus.SUCCESS;
        }
        else
        {
            _navMeshAgent.SetDestination(destination.transform.position);
            return BTNode.NodeStatus.RUNNING;
        }
    }
    private BTNode.NodeStatus GoToDoor(LockableDoor door)
    {
        BTNode.NodeStatus status = GoToDestination(door.gameObject);
        if (status == BTNode.NodeStatus.SUCCESS)
        {
            //Code to handle the door
            if (door.CanOpenTheDoor())
            {
                door.OpenTheDoor();
                return BTNode.NodeStatus.SUCCESS;
            }
            else
            {
                return BTNode.NodeStatus.FAILURE;
            }
        }
        else
        {
            return status;
        }
    }

    private BTNode.NodeStatus goToDiamondBehaviour()
    {
        return GoToDestination(_diamond);
    }
    private BTNode.NodeStatus goToFrontDoorBehaviour()
    {
        return GoToDoor(_frontDoor);
    }
    private BTNode.NodeStatus goToBackDoorBehaviour()
    {
        return GoToDoor(_backDoor);
    }
    private BTNode.NodeStatus goToVanBehaviour()
    {
        return GoToDestination(_van);
    }
}
