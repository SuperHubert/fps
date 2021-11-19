using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public GameObject prefab;

    public Rigidbody rb;

    public float projectileSpeed = 1000;
    
    private GameObject prefabInstance;
    public Transform canon;
    public Transform projectileGroup;
    
    private bool shootOrder;
    
    
    
    void Update()
    {
        shootOrder = Input.GetMouseButtonDown(0);

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
        

    }

    IEnumerator Shoot()
    {
        prefabInstance = Instantiate(prefab, canon.position, canon.rotation,projectileGroup);
        prefabInstance.GetComponent<Rigidbody>().AddForce(canon.forward*projectileSpeed);

        Destroy(prefabInstance,10);

        if (!transform.GetComponent<MoveController>().isGrounded)
        {
            rb.AddForce(-1*transform.GetComponent<MoveController>().jumpForce/2*canon.forward);
        }
        
        yield break;
    }
}
