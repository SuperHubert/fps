using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : WeaponBase
{
    public GameObject mainCamera;
    public GameObject scopeCamera;
    public GameObject particlePrefab;
    private bool isScoped = false;
    protected override void MoreUpdate()
    {
        IsScoped(Input.GetButton("Fire2"));
        mainCamera.SetActive(!Input.GetButton("Fire2"));
        WeaponManager.instance.playerTransform.gameObject.GetComponent<CamRotation>().rotationSpeed = 0.1f;
        scopeCamera.SetActive(Input.GetButton("Fire2"));
    }

    private void IsScoped(bool b)
    {
        if (isScoped == b) return;
        
        if (b)
        {
            isScoped = true;
            mainCamera.SetActive(false);
            scopeCamera.SetActive(true);
            WeaponManager.instance.playerTransform.gameObject.GetComponent<CamRotation>().rotationSpeed = 0.1f;
            return;
        }

        isScoped = false;
        mainCamera.SetActive(true);
        scopeCamera.SetActive(false);
        WeaponManager.instance.playerTransform.gameObject.GetComponent<CamRotation>().rotationSpeed = 0.25f;
    }

    protected override void FireBarrel(int barrelNumber)
    {
        Transform barrel = barrels[barrelNumber];
        
        Vector3 origin = transform.parent.position;
        Vector3 dir = transform.parent.forward;
            
        Debug.DrawRay(origin, dir*1000f, Color.blue,3);
        
        RaycastHit hit;

        if (Physics.Raycast(origin, dir * 1000f, out hit))
        {
            GameObject other = hit.transform.gameObject;

            Destroy(Instantiate(particlePrefab, hit.point, Quaternion.identity), 5);

            if (other.transform.GetComponent<Enemy>() != null)
            {
                other.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        currentAmmo--;
    }

    public void ForceUnScope()
    {
        mainCamera.SetActive(true);
        scopeCamera.SetActive(false);
    }
}
