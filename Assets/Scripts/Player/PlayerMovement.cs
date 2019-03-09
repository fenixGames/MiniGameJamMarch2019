using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private Transform RaycastOrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Time.deltaTime * Input.GetAxis("Horizontal") * speed, 0, Time.deltaTime * Input.GetAxis("Vertical") * speed);

        Ray ray = new Ray(RaycastOrigin.position, -transform.up);

        if (Physics.Raycast(ray, out RaycastHit hit))

        {

           var rot = Quaternion.FromToRotation(transform.up, hit.normal) *
                  transform.rotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, rot,
                Time.deltaTime * 1.5f);

             var currPosition =  transform.position;
             currPosition.y = hit.point.y;
             transform.position = currPosition;
        }


        //transform.Translate(Time.deltaTime * Input.GetAxis("Horizontal") * speed, 0, Time.deltaTime * Input.GetAxis("Vertical") * speed);


        //if (Physics.Raycast(RaycastOrigin.position, -transform.up, out RaycastHit hit, 1000))
        //{
        //    Debug.Log($"hit name {hit.collider.gameObject.name}");
        //    transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        //    var axis = Vector3.Cross(-transform.up, -hit.normal);
        //    var angle = Mathf.Atan2(Vector3.Magnitude(axis), Vector3.Dot(-transform.up, -hit.normal));

        //    transform.RotateAround(axis, angle);

        //}
    }
}
