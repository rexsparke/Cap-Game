using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTileType : MonoBehaviour
{
    ShopManager shopManager;
    public List<Tile> TileList = new List<Tile>();

    void Start()
    {
        
    }

    public Tile GetTile(string pickedTile)
    {
        //for (int i = 0; i < TileList.Count; i++)
        //{
            foreach (Tile tile in TileList)
            {
            Debug.Log("Tile: " + tile.name + " was check!");

                if(tile.name == pickedTile)
                {
                return tile;
                
                }
                
            }
        return null;
        //}
    }
}
