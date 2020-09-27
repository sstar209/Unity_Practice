using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Gizmos : MonoBehaviour
{
    public Color color1 = Color.blue;
    //기즈모 색을 파란색으로

    public float Gizmo_Radius = 0.2f;

    public void OnDrawGizmos()
    {
        Gizmos.color = color1;
        Gizmos.DrawSphere(transform.position, Gizmo_Radius);
    }
}
