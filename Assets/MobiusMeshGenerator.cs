using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), ExecuteInEditMode]
public class MobiusMeshGenerator : MonoBehaviour
{
    [SerializeField]
    private MeshFilter meshFilter;

    public float uvScale = 1;

    [Header("Mesh")]
    public int resolution = 20;
    public float radius = 1;
    public float width = 1;
    public float height = 0.1f;

    // Vertices in clockwise order genrate face towards you
    public void GenerateMesh()
    {
        if (meshFilter == null || resolution < 3) return;
        
        Vector3[] vertices = new Vector3[resolution * 4];
        Vector2[] uvs = new Vector2[resolution * 4];

        float realWidth = width / radius;
        float realHeight = height / radius;

        for (int i = 0; i < resolution; i++)
        {
            float angle = i * Mathf.PI * 2 / resolution;

            vertices[i * 4 + 0] = Mobius.Circle(angle, -realWidth, -realHeight) * radius;
            vertices[i * 4 + 1] = Mobius.Circle(angle, realWidth, -realHeight) * radius;
            
            vertices[i * 4 + 2] = Mobius.Circle(angle, -realWidth, realHeight) * radius;
            vertices[i * 4 + 3] = Mobius.Circle(angle, realWidth, realHeight) * radius;

            uvs[i * 4 + 0] = new Vector2(0, i * uvScale);
            uvs[i * 4 + 1] = new Vector2(1, i * uvScale);

            uvs[i * 4 + 2] = new Vector2(1, i * uvScale);
            uvs[i * 4 + 3] = new Vector2(0, i * uvScale);
        }

        int[] triangles = new int[resolution * 12];

        for (int i = 0; i < resolution - 1; i++)
        {
            // frontside
            triangles[i * 12 +  0] = i * 4 + 4;
            triangles[i * 12 +  1] = i * 4 + 0;
            triangles[i * 12 +  2] = i * 4 + 1;

            triangles[i * 12 +  3] = i * 4 + 1;
            triangles[i * 12 +  4] = i * 4 + 5;
            triangles[i * 12 +  5] = i * 4 + 4;

            // backside
            triangles[i * 12 +  6] = i * 4 + 2;
            triangles[i * 12 +  7] = i * 4 + 6;
            triangles[i * 12 +  8] = i * 4 + 7;

            triangles[i * 12 +  9] = i * 4 + 7;
            triangles[i * 12 + 10] = i * 4 + 3;
            triangles[i * 12 + 11] = i * 4 + 2;
        }

        // last frontside
        triangles[resolution * 12 - 12] = 2;
        triangles[resolution * 12 - 11] = resolution * 4 - 4;
        triangles[resolution * 12 - 10] = resolution * 4 - 3;

        triangles[resolution * 12 -  9] = resolution * 4 - 1;
        triangles[resolution * 12 -  8] = 1;
        triangles[resolution * 12 -  7] = 0;

        // last backside
        triangles[resolution * 12 -  6] = resolution * 4 - 4;
        triangles[resolution * 12 -  5] = 2;
        triangles[resolution * 12 -  4] = 3;

        triangles[resolution * 12 -  3] = 1;
        triangles[resolution * 12 -  2] = resolution * 4 - 1;
        triangles[resolution * 12 -  1] = resolution * 4 - 2;

        Mesh mesh = new Mesh
        {
            vertices = vertices,
            uv = uvs,
            triangles = triangles
        };

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

    public Vector3 GetMobiusPosition(float u, float v, float w = 0)
    {
        return transform.position + transform.rotation * Mobius.Circle(u, v / radius, w / radius) * radius;
    }

    public Quaternion GetMobiusRotation(float u)
    {
        Vector3 centerMob = GetMobiusPosition(u, 0);

        Vector3 forwardNormal = GetMobiusPosition(u + 1 / (radius * Mathf.PI), 0, 0) - centerMob;
        Vector3 upNormal = GetMobiusPosition(u, 0, 1) - centerMob;

        return Quaternion.LookRotation(forwardNormal, upNormal);
    }

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();

        GenerateMesh();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < 40; i++)
        {
            float angle = i / 20.0f * Mathf.PI;

            Vector3 start = GetMobiusPosition(angle, -width);
            Vector3 end = GetMobiusPosition(angle, width);

            Gizmos.DrawLine(start, end);
        }
    }
}
