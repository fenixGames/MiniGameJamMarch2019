using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MobiusMeshGenerator))]
public class MobiusMeshGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MobiusMeshGenerator mobiusMeshGenerator = (MobiusMeshGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate Mesh"))
        {
            mobiusMeshGenerator.GenerateMesh();
        }
    }
}
