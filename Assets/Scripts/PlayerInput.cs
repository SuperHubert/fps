using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CamRotation rotationController;
    private MoveController moveController;
    private ForceANature forceANature;

    private void Start()
    {
        rotationController = transform.GetComponent<CamRotation>();
        moveController = transform.GetComponent<MoveController>();
        forceANature = transform.GetComponent<ForceANature>();
    }

    private void Update()
    {
        rotationController.xAxis = Input.GetAxis("Mouse X");
        rotationController.yAxis = Input.GetAxis("Mouse Y");

        moveController.horizontalAxis = Input.GetAxis("Horizontal");
        moveController.verticalAxis = Input.GetAxis("Vertical");

        forceANature.isTryingToShoot = Input.GetButtonDown("Fire1");
    }
}
