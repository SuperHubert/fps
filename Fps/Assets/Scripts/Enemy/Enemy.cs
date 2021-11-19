using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Random;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public static int killed = 0;
    public int hpCount = 5;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(WeaponManager.instance.playerTransform.position);
    }

    public void TakeDamage(int damage)
    {
        hpCount -= damage;

        if (hpCount > 0) return;

        killed++;
        
        Destroy(gameObject);
        WeaponManager.instance.killedText.text = "Gauthier killed : " + killed;
        Instantiate(WeaponManager.instance.gauthierPrefab, new Vector3(Range(-50f,50f), 0.242f, Range(-50f,50f)), Quaternion.identity);
        Instantiate(WeaponManager.instance.gauthierPrefab, new Vector3(Range(-50f,50f), 0.242f, Range(-50f,50f)), Quaternion.identity);
    }
    
}

