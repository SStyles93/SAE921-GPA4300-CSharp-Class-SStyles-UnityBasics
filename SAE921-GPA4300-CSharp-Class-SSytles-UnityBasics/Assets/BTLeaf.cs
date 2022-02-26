using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTLeaf : BTNode
{
    public delegate NodeStatus Tick();
    public Tick processMethod;

    public BTLeaf(string name, Tick pm) : base(name)
    {
        processMethod = pm;
    }
    public override NodeStatus Process()
    {
        if(processMethod != null)
        {
            return processMethod();
        }
        return NodeStatus.FAILURE;
    }
}
