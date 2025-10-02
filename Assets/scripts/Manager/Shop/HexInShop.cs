using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInShop : MonoBehaviour
{
    public GameObject hexOutline;
    public ShopManager shopManager;

    static int shopPositionSetup = 0;
    int shopPosition;

    void Awake()
    {
        shopPosition = shopPositionSetup;
        shopPositionSetup++;
    }

    private void OnMouseDown()
    {
        Debug.Log(shopPosition);
        shopManager.selectedTile = shopPosition;
    }
}
