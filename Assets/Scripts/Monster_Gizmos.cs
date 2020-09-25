using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Gizmos : MonoBehaviour
{
    public Color color1 = Color.yellow;
    //기즈모 색을 노란색으로 설정
    //*기즈모는 편집화면에서만 보이며 실제 실행 시에는 안 보인다.

    public float Gizmo_Radius = 0.08f;

    public void OnDrawGizmos()
    {
        Gizmos.color = color1;
        Gizmos.DrawSphere(transform.position, Gizmo_Radius);
    }
}
