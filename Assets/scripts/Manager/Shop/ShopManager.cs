using System;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject hexOutline;

    public GameObject[] hexes;

    public GameObject[] currentHexes;

    float spawnY = 3.5f;
    public int selectedTile = 0; //Currently selected tile in the shop

    void Start()
    {
        InitialStock();
    }

    public void InitialStock() //Restocks the shop with 3 new tiles, happens at the start of every build phase
    {
        for (int i = 0; i < 3; i++)
        {
            HexSelection();
            spawnY -= 3.5f;
        }
    }

    public void PlacementBroadcast() //Gathers all current hexes tagged with the ShopHex tag, then calls a placement function in each of them
    {
        currentHexes = GameObject.FindGameObjectsWithTag("ShopHex");
        foreach (GameObject hex in currentHexes)
        {
            hex.SendMessage("Placement");
        }
    }

    public void ReplaceStock(int position) //Replaces a placed hex with a new one
    {
        switch (position)
        {
            case 1:
                spawnY = 3.5f; break;
            case 2:
                spawnY = 0; break;
            case 3:
                spawnY = -3.5f; break;
        }

        HexSelection();
    }

    public void HexSelection()
    {
        int randomHex = UnityEngine.Random.Range(0, 3);
        switch (randomHex)
        {
            case 0:
                GameObject newHex = Instantiate(hexes[0], new Vector3(8.8f, spawnY), Quaternion.identity);
                newHex.GetComponent<HexInShop>().shopManager = this;
                newHex.GetComponent<HexInShop>().hexOutline = hexOutline;
                break;
            case 1:
                GameObject newHexRed = Instantiate(hexes[1], new Vector3(8.8f, spawnY), Quaternion.identity);
                newHexRed.GetComponent<HexInShop>().shopManager = this;
                newHexRed.GetComponent<HexInShop>().hexOutline = hexOutline; 
                break;
            case 2:
                GameObject newHexBlue = Instantiate(hexes[2], new Vector3(8.8f, spawnY), Quaternion.identity);
                newHexBlue.GetComponent<HexInShop>().shopManager = this;
                newHexBlue.GetComponent<HexInShop>().hexOutline = hexOutline; 
                break;
        }
    }
}
