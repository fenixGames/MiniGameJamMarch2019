using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensibility = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Weapon weapon = GetComponent<Weapon>();
            weapon.Attack();
        }

        Camera camera = GetComponent<Camera>();

        float _x = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float _y = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        Vector3 look = transform.position + transform.forward;
        look += transform.right * _x + transform.up * _y;

        transform.LookAt(look);
    }
}
