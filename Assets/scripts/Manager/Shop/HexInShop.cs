using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexInShop : MonoBehaviour
{
    public GameObject hexOutline;
    public ShopManager shopManager;
    public GlobalManager globalManager;

    static int shopPositionSetup = 1;
    int shopPosition;
    public bool canPlace = false;
    public GameObject selectTile;

    void Awake()
    {
        globalManager = GameObject.Find("main").GetComponent<GlobalManager>();
        shopPosition = shopPositionSetup; //Assigns the position variable based on where the tile is in the shop (1-3)
        shopPositionSetup++;
    }

    private void OnMouseDown() //Sets the selected tile in the Shop Manager based on position and adds highlight to current hex
    {
        if (gameObject.tag == "ShopHex")
        {
            shopManager.selectedTile = shopPosition;
            Debug.Log("Selected Tile int is: " + shopManager.selectedTile);
            hexOutline.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            globalManager.canPlace = true;
            selectTile = raycastThing();    //For getting the gameObject
            //selectTile = transform.gameObject;
            Debug.Log("CanPlace = " + globalManager.canPlace);
            Debug.Log("Can place Tile!");
        }
    }

    public void Placement()
    {
        if (shopPosition == shopManager.selectedTile) //Checks to make sure it is the selected tile
        {
            gameObject.tag = "BoardHex"; //Removes ShopHex from tile, preventing further interaction. Then removes outline, deselects the tile, and moves it to the clicked location
            hexOutline.transform.position = new Vector3(20, 0);
            shopManager.selectedTile = 0;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 100);

            shopPositionSetup = shopPosition;
            shopManager.ReplaceStock(shopPosition); //Restocks the shop with a new tile in the position of the old one
        }
    }
    public GameObject raycastThing()
    {
        // Check if hitting a collider in world space
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        if (hit != null && hit.CompareTag("ShopHex"))
        {
            //if (hit.name == "newHex")
            //{
            //    return GameObject.Find(hit.name);
            //}
            //else if (hit.name == "newHexRed")
            //{
            //    return GameObject.Find(hit.name); ;
            //}
            //else if (hit.name == "newHexBlue")
            //{
            //    return GameObject.Find(hit.name); ;
            //}
            return GameObject.Find(hit.name);
        }
        Debug.LogError("raycast object could not be found!");
        return null;
    }
}
