using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public GameObject mainBody;
    private Enemy gauthier;
    private int hpCount;

    private void Start()
    {
        mainBody = transform.parent.gameObject;
        gauthier = mainBody.GetComponent<Enemy>();
        
    }

    public void TakeDamage(int damage)
    {
        gauthier.hpCount -= damage;

        if (gauthier.hpCount <= 0)
        {
            Destroy(mainBody);
        }
    }
}
