using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int hpCount = 10;

    ArrayManager arrayManager;

    public GameObject prefabBlack;
    public GameObject prefabWhite;

    private void Start()
    {
        arrayManager = GameObject.Find("Game Manager").GetComponent<ArrayManager>();
    }

    public void TakeDamage(int damage)
    {
        hpCount -= damage;

        if (hpCount < 1)
        {
            Debug.Log(gameObject.GetComponent<MeshRenderer>().material);
            
            if (gameObject.GetComponent<MeshRenderer>().material == arrayManager.blackMat)
            {
                Destroy(Instantiate(prefabBlack, transform.position, quaternion.identity),5);
            }
            else if (gameObject.GetComponent<MeshRenderer>().material == arrayManager.whiteMat)
            {
                Destroy(Instantiate(prefabWhite, transform.position, quaternion.identity),5);
            }
            
            Destroy(gameObject);
            
        }
    }
}
