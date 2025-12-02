using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeeTile : MonoBehaviour
{
    GlobalManager globalManager;
    public GameObject basicBee;
    int maxSpawn = 1;
    int currentSpawn = 0;
    void Start()
    {
        globalManager = GameObject.Find("main").GetComponent<GlobalManager>();
    }
    void Update()
    {
        if (globalManager.attackPase == true && currentSpawn != maxSpawn)
        {
            SpawnBasicBee();
        }
    }
    public void SpawnBasicBee()
    {
        if (this.CompareTag("BoardHex"))
            if (globalManager.attackPase == true && currentSpawn != maxSpawn)
            {
                Instantiate(basicBee, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                currentSpawn++;
            }
    }
}
