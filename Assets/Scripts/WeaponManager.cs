using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons;
    public int currentWeapon;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI killedText;
    public Image reloadingImage;
    public Transform playerTransform;
    public GameObject gauthierPrefab;

    
    #region Singleton

    public static WeaponManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public void NextWeapon()
    {
        if (weapons[currentWeapon].GetComponent<WeaponBase>().isReloading) return;
        
        if (weapons[currentWeapon].GetComponent<Sniper>() != null)
        {
            weapons[currentWeapon].GetComponent<Sniper>().ForceUnScope();
        }
        
        weapons[currentWeapon].SetActive(false);
        currentWeapon++;
        if (currentWeapon >= weapons.Count)
        {
            currentWeapon = 0;
        }
        weapons[currentWeapon].SetActive(true);
        weapons[currentWeapon].GetComponent<WeaponBase>().UpdateAmmoDisplay();
    }

    public GameObject GetCurrentWeapon()
    {
        return weapons[currentWeapon];
    }

    public void UpdateAmmoCount(string text)
    {
        ammoText.text = text;
    }

    public void UpdateReloading(float progress)
    {
        if (progress > 1)
        {
            progress = 0;
        }
        reloadingImage.fillAmount = progress;

    }
}
