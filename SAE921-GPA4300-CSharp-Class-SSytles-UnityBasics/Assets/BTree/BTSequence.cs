using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTNode
{
    public BTSequence(string name) : base(name) {}

    public override NodeStatus Process()
    {
        NodeStatus status;
        if (_currentChildIdx < _children.Count)
            status = _children[_currentChildIdx].Process();
        else
        {
            Debug.Log("End of sequence");
            status = NodeStatus.SUCCESS;
        }

        if (status == NodeStatus.SUCCESS)
        {
            _currentChildIdx++;
            if(_currentChildIdx < _children.Count)
            {
                status = NodeStatus.RUNNING;
            }   
        }
        Debug.Log($"{status}");
        return status;
    }
}
