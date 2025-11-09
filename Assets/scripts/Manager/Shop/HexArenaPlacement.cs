using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexArenaPlacement : MonoBehaviour
{
    public ShopManager shopManager;
    public HexInShop hexInShop;

    private void OnMouseDown() //Triggers Placement.
    {
        if (shopManager.selectedTile != 0)
        {
            Debug.Log("Placed tile " + shopManager.selectedTile);
            shopManager.PlacementBroadcast();
        }
    }
}
