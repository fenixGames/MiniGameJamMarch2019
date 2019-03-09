using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathExtract : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] vertices;

    public Vector3[] WorldPosition;
    // Start is called before the first frame update
    void Awake()
    {
        ExtractPath();
    }
    public void ExtractPath()
    {
        WorldPosition = new Vector3[vertices.Length];
        mesh = GetComponent<MeshFilter>().sharedMesh;
        vertices = mesh.vertices;
        int index = 0;
        foreach (var vertPosition in vertices)
        {
            WorldPosition[index++] = transform.TransformPoint(vertPosition);
        }
    }


}
