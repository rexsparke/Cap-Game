using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeeTile : MonoBehaviour
{
    GlobalManager globalManager;
    public GameObject basicBee;
    int maxSpawn = 1;
    public int currentSpawn = 0;
    public class beeSprites
    {
        string Bees;
        bool isDead;
    }
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
                GameObject newBee= Instantiate(basicBee, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                Bee beebasic = newBee.GetComponent<Bee>();
                beebasic.basicBee = this;
                currentSpawn++;
                Debug.Log("New bee spawned!!");
            }
            //else if(globalManager.buildPase == true && currentSpawn != maxSpawn)
            //{
            //    currentSpawn = (maxSpawn - currentSpawn);
            //    Debug.Log("Current Spawn is: " + currentSpawn);
            //}
    }
}
