using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    public Vector3 center;
    public float radius = 1;
    [Range(0, Mathf.PI * 2)]
    public float rotationOffset = 0;
    // public bool clockwise = true;

    public float theta = 0;
    public float phi = 0;
    
    Vector3 Mobius(float u, float v)
    {
        return new Vector3(
            (1 + v / 2 * Mathf.Cos(u / 2 + rotationOffset)) * Mathf.Cos(u),
            (1 + v / 2 * Mathf.Cos(u / 2 + rotationOffset)) * Mathf.Sin(u),
            v / 2 * Mathf.Sin(u / 2)
        );
    }
    
    Quaternion QuaternionFromTwoVectors(Vector3 u, Vector3 v)
    {
        float norm_u_norm_v = Mathf.Sqrt(Vector3.Dot(u, u) * Vector3.Dot(v, v));
        float real_part = norm_u_norm_v + Vector3.Dot(u, v);
        Vector3 w;

        if (real_part < 1e-6f * norm_u_norm_v)
        {
            /* If u and v are exactly opposite, rotate 180 degrees
             * around an arbitrary orthogonal axis. Axis normalisation
             * can happen later, when we normalise the quaternion. */
            real_part = 0.0f;
            w = Mathf.Abs(u.x) > Mathf.Abs(u.z) ? new Vector3(-u.y, u.x, 0f)
                                    : new Vector3(0f, -u.z, u.y);
        }
        else
        {
            /* Otherwise, build quaternion the standard way. */
            w = Vector3.Cross(u, v);
        }

        return new Quaternion(real_part, w.x, w.y, w.z).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        theta += 0.01f;

        Vector3 newPos = center + Mobius(theta, phi);

        Vector3 normalMobius = Mobius(theta, 1) - Mobius(theta, 0);

        Vector3 centerMob = Mobius(theta, 0);
        
        transform.rotation = Quaternion.LookRotation(normalMobius, new Vector3(-Mathf.Sin(theta), Mathf.Cos(theta), 0));
        transform.position = newPos * radius;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Mobius(theta, 1) * radius, Mobius(theta, 0) * radius);
        Vector3 centerMob = Mobius(theta, 0) * radius;
        Vector3 normal = new Vector3(-Mathf.Sin(theta), Mathf.Cos(theta), 0);
        Gizmos.DrawLine(centerMob, centerMob + normal);

        Gizmos.color = Color.white;
        for (int i = 0; i < 40; i++)
        {
            float angle = i / 20.0f * Mathf.PI;

            Gizmos.DrawLine(Mobius(angle, -1) * radius, Mobius(angle, 1) * radius);
        }
    }
}
