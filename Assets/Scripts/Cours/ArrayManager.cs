using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrayManager : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject prefab;

    public float decal = 1.5f;
    public Material whiteMat;
    public Material blackMat;

    public GameObject[,] cubes2DArray;
    public GameObject[,,] cubes3DArray;

    public GameObject[][] jaggedArray;

    public int size;

    void Start()
    {
        JaggedPyramid();
    }

    private void JaggedPyramid()
    {
        jaggedArray = new GameObject[size][];

        for (int y = 0; y < jaggedArray.Length / 2 + 1; y++)
        {
            for (int x = 0 + y; x < jaggedArray.Length - y; x++)
            {
                jaggedArray[x] = new GameObject[y + 1];
            }
        }

        for (int x = 0; x < jaggedArray.Length; x++)
        {
            for (int y = 0; y < jaggedArray[x].Length; y++)
            {
                jaggedArray[x][y] = Instantiate(prefab, new Vector3(decal * x, decal * y, 0), Quaternion.identity,
                    transform);
                jaggedArray[x][y].GetComponent<MeshRenderer>().material = ((y + x) % 2 == 0) ? blackMat : whiteMat;
            }
        }
    }

    private void Init3DArray()
    {
        cubes3DArray = new GameObject[8,8,8];

        for (int x = 0; x < cubes3DArray.GetLength(0); x++)
        {
            for (int y = 0; y < cubes3DArray.GetLength(1); y++)
            {
                for (int z = 0; z < cubes3DArray.GetLength(2); z++)
                {
                    cubes3DArray[x,y,z] = Instantiate(prefab, new Vector3(decal * x, decal * y, decal * z), Quaternion.identity,
                        transform);
                    if ((y+x+z)% 2 == 0)
                    {
                        cubes3DArray[x,y,z].GetComponent<MeshRenderer>().material = blackMat;
                    }
                    else
                    {
                        cubes3DArray[x,y,z].GetComponent<MeshRenderer>().material = whiteMat;
                    }
                }
            }
        }
    }
    
    private void Init1DArray()
    {
        cubes = new GameObject[64];

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = Instantiate(prefab, new Vector3(-49 + 1.5f * i, 0, 0), Quaternion.identity, transform);
            cubes[i].name = i.ToString();
            if (i % 2 == 0)
            {
                cubes[i].GetComponent<MeshRenderer>().material = blackMat;
            }
            else
            {
                cubes[i].GetComponent<MeshRenderer>().material = whiteMat;
            }
        }
    }

    private void Init2DArray()
    {
        cubes2DArray = new GameObject[16, 32];

        for (int x = 0; x < cubes2DArray.GetLength(0); x++)
        {
            for (int y = 0; y < cubes2DArray.GetLength(1); y++)
            {
                cubes2DArray[x, y] = Instantiate(prefab, new Vector3(decal * x, 0, decal * y), Quaternion.identity,
                    transform);
                if ((y+x)% 2 == 0)
                {
                    cubes2DArray[x, y].GetComponent<MeshRenderer>().material = blackMat;
                }
                else
                {
                    cubes2DArray[x, y].GetComponent<MeshRenderer>().material = whiteMat;
                }
            }
        }
    }
}
