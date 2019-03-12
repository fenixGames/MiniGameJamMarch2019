using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobius
{
    public static Vector3 Circle(float u, float v, float w = 0)
    {
        float scalar = 1 + v / 2 * Mathf.Cos(u / 2) + w / 2 * Mathf.Sin(u / 2);

        return new Vector3(
            scalar * Mathf.Cos(u),
            scalar * Mathf.Sin(u),
            v / 2 * Mathf.Sin(u / 2) - w / 2 * Mathf.Cos(u / 2)
        );
    }
}
