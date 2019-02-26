using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    public int Count = 3;
    public Vector3 Offset;
    public GameObject Prefab;    

    private void Start()
    {
        CreatObj();
    }

    public void CreatObj()
    {
        for (int i = 0; i < Count; i++)
            Instantiate(Prefab, Offset*i, Quaternion.identity);       
    }
}
