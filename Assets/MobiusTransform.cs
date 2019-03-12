using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobiusTransform : MonoBehaviour
{
    public MobiusMeshGenerator mobiusMesh;
    public Vector3 position;
    // TODO: Custom rotation

    private void ApplyTransform()
    {
        transform.rotation = mobiusMesh.GetMobiusRotation(position.z);
        transform.position = mobiusMesh.GetMobiusPosition(position.z, position.x, position.y);
    }

    void Update()
    {
        if (mobiusMesh == null) return;
        
        ApplyTransform();
    }

    private void OnDrawGizmos()
    {
        if (mobiusMesh == null) return;

        Vector3 centerMob = mobiusMesh.GetMobiusPosition(position.z, 0);

        Vector3 forwardMobius = mobiusMesh.GetMobiusPosition(position.z + 1/(2 * mobiusMesh.radius * Mathf.PI), 0, 0);
        Vector3 upMobius = mobiusMesh.GetMobiusPosition(position.z, 0, 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(centerMob, forwardMobius);
        Gizmos.DrawLine(centerMob, upMobius);
    }
}
