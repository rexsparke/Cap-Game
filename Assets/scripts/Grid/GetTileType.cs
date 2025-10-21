using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTileType : MonoBehaviour
{
    ShopManager shopManager;    //Declared a public reference to script
    public List<Tile> TileList = new List<Tile>();

    public Tile GetTile(string pickedTile)  //Gets tile type by name
    {
        if (shopManager != null)
        {
            //return TileList[shopManager.selectedTile];
            foreach (Tile tile in TileList)
            {
                Debug.Log("Tile: " + tile.name + " was check!");

                if (tile.name == pickedTile)
                {
                    return tile;
                }
            }
        }
        else
        {
            Debug.LogError("Script Not their");
        }
        return null;
    }
    public Tile GetTiles(int selectedTile)  //Gets tile type by index number
    {
        Debug.Log("Tile changed to: " + TileList[selectedTile].name);
        return TileList[selectedTile];
    }
}
