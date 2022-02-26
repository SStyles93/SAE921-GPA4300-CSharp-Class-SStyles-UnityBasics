using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTree : BTNode
{
    public BTTree(string name) : base(name)
    {

    }

    public void printTree()
    {
        Debug.Log(ToString());
    }
}
