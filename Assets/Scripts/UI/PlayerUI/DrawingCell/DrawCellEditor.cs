using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DrawCell))]
public class DrawCellEditor : OdinEditor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DrawCell drawCell = (DrawCell)target;

        if (GUILayout.Button("Create cells"))
        {
            drawCell.CreateNewCells();
        }

        if (GUILayout.Button("Delete current cells"))
        {
            drawCell.DestroyCurrentCells();
        }
    }
}
