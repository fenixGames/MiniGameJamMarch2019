using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private Transform RaycastOrigin;
    // Start is called before the first frame update

    public PathExtract pathExtract;

    void Start()
    {
        transform.position = pathExtract.WorldPosition[0];
        InvokeRepeating("ChangePositionInvokeR",0,.1f);
    }

    private int currentVertexIndex = 0;
    private Vector3 currentPosition;
   
    void ChangePositionInvokeR()
    {
        currentPosition = pathExtract.WorldPosition[currentVertexIndex];
        currentVertexIndex = (currentVertexIndex+1) % pathExtract.vertices.Length;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, currentPosition, Time.deltaTime * 10);

        Ray ray = new Ray(RaycastOrigin.position, -transform.up);

        if (Physics.Raycast(ray, out RaycastHit hit))

        {

            var rot = Quaternion.FromToRotation(transform.up, hit.normal) *
                   transform.rotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, rot,
                Time.deltaTime*10);

            var currPosition = transform.position;
            currPosition.y = Mathf.Lerp(currPosition.y, hit.point.y,Time.deltaTime);
            transform.position = currPosition;
        }
    }
}
