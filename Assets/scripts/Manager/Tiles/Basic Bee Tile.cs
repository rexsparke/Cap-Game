using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeeTile : MonoBehaviour
{

    public GameObject hexes;

    void Start()
    {
        GameObject newHex = Instantiate(hexes, new Vector3(0f, 0f), Quaternion.identity);
    }
}
