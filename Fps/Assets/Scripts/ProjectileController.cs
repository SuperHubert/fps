using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject prefab;

    public int damage = 6;
    
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        Destroy(Instantiate(prefab, transform.position, transform.rotation), 5);

        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
