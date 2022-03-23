using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float bounceForce;
    public float bounceRadius; 

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach (var segment in segments)
        {
            segment.Bounce(bounceForce, transform.position, bounceRadius);
        }
        Destroy(gameObject, 0.5f);
    }
}
