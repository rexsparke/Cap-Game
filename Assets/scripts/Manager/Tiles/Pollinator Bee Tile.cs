using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinatorBeeTile : MonoBehaviour
{
    GlobalManager globalManager;
    public GameObject pollinatorBee;
    public GameObject flowerTile;
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
            SpawnPollinatorBee();
        }
    }
    public void SpawnPollinatorBee()
    {
        if (this.CompareTag("BoardHex"))
            if (globalManager.attackPase == true && currentSpawn != maxSpawn)
            {
                GameObject newBee = Instantiate(pollinatorBee, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                newBee.GetComponent<PollinatorBeeScript>().flowerTile = flowerTile;

                //PollinatorBeeScript pollinator = newBee.GetComponent<pollinatorBee>();
                // pollinator.pollinatorBee = this;
                currentSpawn++;
                Debug.Log("POLLINATORSPWANEEDNEd!!");
            }
        //else if(globalManager.buildPase == true && currentSpawn != maxSpawn)
        //{
        //    currentSpawn = (maxSpawn - currentSpawn);
        //    Debug.Log("Current Spawn is: " + currentSpawn);
        //}
    }
}
