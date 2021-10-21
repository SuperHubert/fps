using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recap : MonoBehaviour
{
    public Transform target;
    public float value = 0.01f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, value * Time.deltaTime);
    }
}
