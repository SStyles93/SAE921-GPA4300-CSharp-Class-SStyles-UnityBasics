using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    private BTTree _robberTree;
    private BTNode _goToDoor;
    private BTNode _goToDiamond;
    private BTNode _goToVan;
    private BTNode _goToOther;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject _diamond;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _van;
    [SerializeField] private GameObject _other;

    void Start()
    {
        if (TryGetComponent<NavMeshAgent>(out _navMeshAgent) == false)
            Debug.Log("No nav mesh agent !!!");

        _robberTree = new BTTree("Root");
        _goToDiamond = new BTLeaf("Go To Diamond", goToDiamondBehaviour);
        _goToDoor = new BTLeaf("Go To Door", goToDoorBehaviour);
        _goToVan = new BTLeaf("Go To Van", goToVanBehaviour);
        _goToOther = new BTLeaf("Go To Other", goToOtherBehaviour);

        _robberTree.AddChild(_goToDoor);
        _robberTree.AddChild(_goToDiamond);
        _robberTree.AddChild(_goToVan);
        _goToDiamond.AddChild(_goToOther);

        _robberTree.printTree();
    }

    private BTNode.NodeStatus goToDiamondBehaviour()
    {
        return GoToDestination(_diamond);
    }
    private BTNode.NodeStatus goToDoorBehaviour()
    {
        return GoToDestination(_door);
    }
    private BTNode.NodeStatus goToVanBehaviour()
    {
        return GoToDestination(_van);
    }
    private BTNode.NodeStatus goToOtherBehaviour()
    {
        return GoToDestination(_other);
    }

    private BTNode.NodeStatus GoToDestination(GameObject destination)
    {
        if (Vector3.Distance(_diamond.gameObject.transform.position, transform.position) < Mathf.Epsilon)
        {
            return BTNode.NodeStatus.SUCCESS;
        }
        else
        {
            _navMeshAgent.SetDestination(destination.transform.position);
            return BTNode.NodeStatus.RUNNING;
        }
    }

}
