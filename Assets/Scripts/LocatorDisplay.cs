using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatorDisplay : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
