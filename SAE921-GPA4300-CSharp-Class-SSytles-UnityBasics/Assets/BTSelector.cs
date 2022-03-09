using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTNode
{
    public BTSelector(string name) : base(name) { }

    public override NodeStatus Process()
    {
        NodeStatus status;
        if (_currentChildIdx < _children.Count)
        {
            status = _children[_currentChildIdx].Process();
        }
        else
        {
            status = NodeStatus.SUCCESS;
        }
            
        if(status == NodeStatus.FAILURE)
        {
            _currentChildIdx++;
        }

        return status;
    }
}
