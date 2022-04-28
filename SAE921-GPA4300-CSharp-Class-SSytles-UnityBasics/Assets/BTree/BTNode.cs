using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNode
{
    public enum NodeStatus
    {
        FAILURE,
        RUNNING,
        SUCCESS,
    }

    protected string _name;
    protected int _level = 0;
    protected List<BTNode> _children = new List<BTNode>();

    protected int _currentChildIdx = 0;

    public BTNode(string name)
    {
        _name = name;
    }
    public void AddChild(BTNode nodeToAdd)
    {
        nodeToAdd._level = _level+1;
        _children.Add(nodeToAdd);
    }
    public override string ToString()
    {
        string log = "";
        
        log += new string('-', _level) + _level  + "-" + _name + "\n";
        foreach(var child in _children)
        {
            log += child.ToString();
        }

        return log;
    }
    public virtual NodeStatus Process()
    {
        if(_currentChildIdx < _children.Count)
        {
            return _children[_currentChildIdx].Process();
        }
        return NodeStatus.FAILURE;
        
    }
}


