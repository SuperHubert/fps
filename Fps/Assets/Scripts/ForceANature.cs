using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceANature : MonoBehaviour
{
    Animator animator;
    public Transform leftBarrel;
    public Transform rightBarrel;
    public GameObject bulletPrefab;
    
    public bool isTryingToShoot = false;
    
    public float bulletForce;
    
    private int ammoCount = 2;

    private void Start()
    {
        animator = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        if (isTryingToShoot)
        {
            switch (ammoCount)
            {
                case 2:
                    Fire(rightBarrel);
                    break;
                
                case 1:
                    Fire(leftBarrel);
                    break;
                
                case 0:
                    Reload();
                    break;
                
                default:
                    Reload();
                    break;
            }
        }
    }

    void Fire(Transform barrel)
    {
        GameObject prefabInstance = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        prefabInstance.GetComponent<Rigidbody>().AddForce(barrel.forward*bulletForce);

        Destroy(prefabInstance,10);

        ammoCount--;
    }

    void Reload()
    {
        animator.SetTrigger("Reload");

        ammoCount = 2;
    }
}
