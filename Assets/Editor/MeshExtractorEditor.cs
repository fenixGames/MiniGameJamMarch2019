using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(PathExtract))]
public class MeshExtractorEditor : Editor
{
    private PathExtract pathExtract;
    void OnEnable()
    {
        pathExtract = (PathExtract) target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("GenerateList"))
        {
            pathExtract.ExtractPath();
        }
        DrawDefaultInspector();
        
    }
}
