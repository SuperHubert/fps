using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    public Transform head;
    public float rotationSpeed = 1;
    public float lookXLimit = 75;
    public float yAxis;
    public float xAxis;
    
    private float rotationX;
    
    void Update()
    {
        rotationX -= yAxis*rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        head.localRotation = quaternion.Euler(rotationX,0,0);
        
        transform.rotation *= quaternion.Euler(0,xAxis*rotationSpeed,0);
    }
}
