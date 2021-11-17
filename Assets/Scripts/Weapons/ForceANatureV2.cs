using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForceANatureV2 : WeaponBase
{
    
    [SerializeField] private GameObject player;
    private Rigidbody rb;
    [SerializeField] private float knockbackForce;

    protected override void MoreStart()
    {
        player = transform.parent.parent.gameObject;
        rb = player.GetComponent<Rigidbody>();
    }
    
    protected override void FireBarrel(int barrelNumber)
    {
        Transform barrel = barrels[barrelNumber];
        
        GameObject prefabInstance = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        prefabInstance.GetComponent<Rigidbody>().AddForce(barrel.forward*bulletForce);
        
        Destroy(prefabInstance,10);

        currentAmmo--;
        
        player.GetComponent<MoveController>().Knockback();
        
    }
    
}
