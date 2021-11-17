using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected List<Transform> barrels;
    [SerializeField] protected GameObject bulletPrefab;
    public bool isTryingToShoot = false;
    public bool isTryingToReload;
    
    [SerializeField] protected int damage;
    
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected int currentAmmo;
    
    [SerializeField] protected float bulletForce;
    
    protected Animator animator;
    [SerializeField] protected float reloadDuration;
    public bool isReloading;
    
    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
        MoreStart();
    }
    
    void Update()
    {
        if (isTryingToReload)
        {
            TryToReload();
        }
        
        if (isTryingToShoot)
        {
            TryToFire();
        }
        
        MoreUpdate();
    }

    protected virtual void MoreStart()
    {
        
    }

    protected virtual void MoreUpdate()
    {
        
    }

    protected virtual void TryToReload()
    {
        if(isReloading || currentAmmo == maxAmmo) return;
        
        StartReload();
    }
    
    protected virtual void FireBarrel(int barrelNumber)
    {
        Transform barrel = barrels[barrelNumber];
        
        GameObject prefabInstance = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        prefabInstance.GetComponent<Rigidbody>().AddForce(barrel.forward*bulletForce);
        
        Destroy(prefabInstance,10);

        currentAmmo--;
    }

    protected virtual void StartReload()
    {
        isReloading = true;
        StartCoroutine(Reload());
    }

    private int GetBarrelToFire()
    {
        return (currentAmmo % barrels.Count);
    }

    protected virtual void TryToFire()
    {
        if(isReloading) return;
        
        if (currentAmmo <= 0)
        {
            UpdateAmmoDisplay();
            StartReload();
            return;
        }
        
        FireBarrel(GetBarrelToFire());
        
        UpdateAmmoDisplay();

        if (currentAmmo > 0) return;
        StartReload();
    }

    IEnumerator Reload()
    {
        animator.SetTrigger("Reload");

        for (int i = 0; i < 101; i++)
        {
            WeaponManager.instance.UpdateReloading(i/100f);
            yield return new WaitForSeconds(reloadDuration/100f);
        }

        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
        isReloading = false;
    }
    
    public void UpdateAmmoDisplay()
    {
        WeaponManager.instance.UpdateAmmoCount(currentAmmo+" / "+maxAmmo);
    }

}
