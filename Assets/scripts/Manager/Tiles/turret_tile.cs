using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_tile : MonoBehaviour
{
    GlobalManager globalManager;
    public GameObject turretSprite;
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
            SpawnTurret();
        }
    }
    public void SpawnTurret()
    {
        if (this.CompareTag("BoardHex"))
            if (globalManager.attackPase == true && currentSpawn != maxSpawn)
            {
                GameObject newTurret = Instantiate(turretSprite, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                currentSpawn++;
            }

    }
}
