using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    private MoveController moveController;

    private void Start()
    {
        moveController = transform.GetComponent<MoveController>();
    }
    
    private void OnCollisionStay(Collision other)
    {
        moveController.isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        moveController.isGrounded = false;
    }
}
