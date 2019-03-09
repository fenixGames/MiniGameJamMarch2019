using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathExtract : MonoBehaviour
{
    public Transform BoxHolder;
    Mesh mesh;
    public Vector3[] vertices;

    public Vector3[] WorldPosition;

    public List<Transform> BoxList;
    // Start is called before the first frame update
    void Awake()
    {
        //ExtractPath();
    }

    
    public void ExtractPath()
    {
        for(int i=0;i< BoxHolder.childCount; i++) {
            Destroy(BoxHolder.GetChild(i));
        }
        BoxList = new List<Transform>();
        WorldPosition = new Vector3[vertices.Length];
        mesh = GetComponent<MeshFilter>().sharedMesh;
        vertices = mesh.vertices;
        int index = 0;
        foreach (var vertPosition in vertices)
        {
            WorldPosition[index] = transform.TransformPoint(vertPosition);

           GameObject box=  GameObject.CreatePrimitive(PrimitiveType.Cube);
           box.transform.position = WorldPosition[index];
           DestroyImmediate(box.GetComponent<BoxCollider>());
           box.transform.parent = BoxHolder;
           BoxList.Add(box.transform);
           index++;
        }

        var factor = 1/BoxList.Count;
        var startBox = BoxList[0];
        var lastBox = BoxList[BoxList.Count-1];
        float value = 0;
        foreach (var box in BoxList)
        {
            box.rotation = Quaternion.Lerp(startBox.rotation, lastBox.rotation, value);
            value += factor;
        }

        
    }


}
