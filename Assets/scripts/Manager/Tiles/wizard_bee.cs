using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class wizard_bee : MonoBehaviour
{
    GlobalManager globalManager;
    public GameObject wzardBeeSprit;
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
            SpawnWizardBee();
        }
    }
    public void SpawnWizardBee()
    {
        if(globalManager.attackPase == true && currentSpawn != maxSpawn)
        {
            GameObject newHex = Instantiate(wzardBeeSprit, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            currentSpawn++;
        }
        
    }

}
