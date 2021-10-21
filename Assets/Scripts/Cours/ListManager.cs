using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    public List<int> ints;
    void Start()
    {
        for (int i = 999; i >= 0; i--)
        {
            ints.Add(i);
        }

        for (int i = 999; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                ints.RemoveAt(i); 
            }
        }
    }

    void Update()
    {
        
    }
}
