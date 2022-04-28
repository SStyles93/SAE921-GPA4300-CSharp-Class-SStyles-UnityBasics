using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PCGTileMap))]
public class PCGEditorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PCGTileMap pcgTileMap = (PCGTileMap)target;

        if (GUI.Button(new Rect(0,0,100,10), "GenerateMap"))
        {
            pcgTileMap.GenerateMap();
        }
    }
}
