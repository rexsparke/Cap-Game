using System;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject hexOutline;

    public GameObject[] hexes;

    public GameObject[] currentHexes;

    //List of GameObjects for tiles
    public GameObject pollinatorBee;
    public GameObject flowerTile;



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
                GameObject basicHex = Instantiate(hexes[0], new Vector3(8.8f, spawnY), Quaternion.identity);
                basicHex.GetComponent<HexInShop>().shopManager = this;
                basicHex.GetComponent<HexInShop>().hexOutline = hexOutline;
                break;
            case 1:
                GameObject wizardHex = Instantiate(hexes[1], new Vector3(8.8f, spawnY), Quaternion.identity);
                wizardHex.GetComponent<HexInShop>().shopManager = this;
                wizardHex.GetComponent<HexInShop>().hexOutline = hexOutline; 
                break;
            case 2:
                GameObject pollenHex = Instantiate(hexes[2], new Vector3(8.8f, spawnY), Quaternion.identity);
                pollenHex.GetComponent<HexInShop>().shopManager = this;
                pollenHex.GetComponent<HexInShop>().hexOutline = hexOutline;
                pollenHex.GetComponent<PollinatorBeeTile>().pollinatorBee = pollinatorBee;
                pollenHex.GetComponent<PollinatorBeeTile>().flowerTile = flowerTile;
                break;
        }
    }
}
