using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMobiusMovement : MonoBehaviour
{
    public float speed = 1;
    [SerializeField]
    private MobiusTransform mobiusTransform;
    
    void Awake()
    {
        mobiusTransform = GetComponent<MobiusTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mobiusTransform != null)
        {
            mobiusTransform.position.z += Time.deltaTime * speed;
        }
    }
}
