using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHexSpawning : MonoBehaviour
{
    public GameObject hex;

    void Start()
    {
        InitialStock();
    }

    void Update()
    {
        
    }

    public void InitialStock() //Restocks the shop with 3 new tiles, happens at the start of every build phase
    {
        float spawnY = 3.5f;

        for (int i = 0; i < 3; i++)
        {
            Instantiate(hex, new Vector3(9.85f, spawnY), Quaternion.identity);
            spawnY -= 3.5f;
        }
    }
}
