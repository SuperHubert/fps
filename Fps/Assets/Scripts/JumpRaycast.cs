using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRaycast : MonoBehaviour
{
    public Rigidbody rb;

    public float jumpStrength = 100;

    public KeyCode jumpKey = KeyCode.Space;

    public float rayDist = 1;
    
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Vector3 origin = transform.position;
            Vector3 dir = Vector3.down;
            
            Debug.DrawRay(origin, dir*rayDist, Color.blue,3);

            if (Physics.Raycast(origin, dir, rayDist))
            {
                rb.AddForce(Vector3.up*jumpStrength);
            }
        }
    }
}
