using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeeTile : MonoBehaviour
{

    public GameObject basicBee;

    void Start()
    {
        GameObject newHex = Instantiate(basicBee, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
