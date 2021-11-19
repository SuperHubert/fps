using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CamRotation rotationController;
    private MoveController moveController;
    [SerializeField] private WeaponManager weaponManager;

    private void Start()
    {
        rotationController = transform.GetComponent<CamRotation>();
        moveController = transform.GetComponent<MoveController>();
    }

    private void Update()
    {
        rotationController.xAxis = Input.GetAxis("Mouse X");
        rotationController.yAxis = Input.GetAxis("Mouse Y");

        moveController.horizontalAxis = Input.GetAxis("Horizontal");
        moveController.verticalAxis = Input.GetAxis("Vertical");
        
        weaponManager.GetCurrentWeapon().GetComponent<WeaponBase>().isTryingToShoot = Input.GetButtonDown("Fire1");
        weaponManager.GetCurrentWeapon().GetComponent<WeaponBase>().isTryingToReload = Input.GetKeyDown(KeyCode.R);
        
        Screen.lockCursor = !Input.GetKey(KeyCode.Tab);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            weaponManager.NextWeapon();
        }
        
    }
}
