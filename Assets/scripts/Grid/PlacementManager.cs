using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlacementManager : MonoBehaviour
{
    public Tilemap hexTileMap;
    public Grid grid;

    public GlobalManager globalMan;
    ShopManager shopMan;
    HexInShop hexShop;
    public Text shopCounter;

    public GameObject hexObject;
    public int maxTiles;
    public int currentTilesAmo;

    void Start()
    {
        maxTiles = 3;
        currentTilesAmo = 3;
        shopMan = GetComponent<ShopManager>();
        globalMan = GetComponent<GlobalManager>();
        shopCounter.text = "Amount of Tiles Left: " + currentTilesAmo + " / " + maxTiles;

        #region Debug
        //if (hexTileMap != null && selectedTile != null)
        //{
        //    Debug.Log("Placing test tile at (0,0)");
        //    hexTileMap.SetTile(Vector3Int.zero, selectedTile);
        //}
        //else
        //{
        //    Debug.LogError("Tilemap or Tile not assigned!");
        //}
        #endregion
    }
    void Update()
    {
        if (globalMan.canPlace == true)
        {
            if (Input.GetMouseButtonDown(0) && raycastThing() == true)
            {
                if (currentTilesAmo != 0)
                {
                    if (shopMan.selectedTile != 0)
                    {
                        Debug.Log("Placed tile " + shopMan.selectedTile);
                        shopMan.PlacementBroadcast();
                    }
                
                    ////Get Tile For placement
                    //Get world position of mouse
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

                    //Returns the integer coordinates of the cell on the tilemap or grid if i tried.
                    Vector3Int cellPos = grid.WorldToCell(mouseWorldPos);

                    Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);
                    Debug.Log("Mouse clicked!");
                    //Vector3Int cellPos = GetCelPosition();
                    //Checks If
                    if (!hexTileMap.HasTile(cellPos))
                    {
                        //Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);
                        PlaceObjectAtCellCenter(cellPos, currentTilesAmo);
                        shopCounter.text = "Amount of Tiles Left: " + --currentTilesAmo + " / " + maxTiles;
                    }
                    #region Debug
                    //if(hexTileMap == null)
                    //{
                    //    Debug.LogError("HexTileMap is not assigned!");
                    //}
                    //if(selectedTile == null)
                    //{
                    //    Debug.LogError("SelectedTile is not assigned!");
                    //}
                    #endregion

                }
                else
                {
                    Debug.Log("You used all your Tiles from shop");
                }
            }
            //else
            //{
            //    Debug.Log("You Have to choose another Tile!");
            //}
        }
        if(globalMan.buildPase == true)
        {
            shopCounter.text = "Amount of Tiles Left: " + currentTilesAmo + " / " + maxTiles;
        }
    }
    public void PlaceObjectAtCellCenter(Vector3Int cellPos, int curretTiles)
    {
        //Vector3 cellWorldPos = hexTileMap.CellToWorld(cellPos);
        //Vector3Int cellPosition = grid.LocalToCell(mouseWorldPos);
        if (grid == null)
        {
            Debug.LogError("Grid reference is missing!");
            return;
        }
        if (shopMan == null)
        {
            Debug.LogError("Shop manager or selected tile is missing!");
            return;
        }
        //Get grid cell center
        Vector3 cellCenter = hexTileMap.GetCellCenterWorld(cellPos);
        cellCenter.z = 0f;

        // Place Tile
        if(hexObject == null)
        {
            Debug.LogError("HepShop Selected Tile is Null!");
        }
        hexObject.transform.position = cellCenter;
        //hexTileMap.SetTile(cellPos, selectedTile);  //For checking If their is a tile their
        Debug.Log(hexObject + " was placed");

        globalMan.canPlace = false;

        //Debug Stuff
        Debug.Log("CanPlace equals: " + globalMan.canPlace);
        Debug.Log("Tile Object placed!");
        Debug.Log("Can't place anymore!");
    }
    public bool raycastThing()
    {
        // Prevent placement if clicking UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        // Check if hitting a collider in world space
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        if (hit != null && (hit.CompareTag("UI") || hit.CompareTag("ShopHex")))
        {
            return false;
        }
        if (hit != null && (hit.CompareTag("BoardHex")))
        {
            return false;
        }
        return true;
        #region stuff
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //// Get mouse position in screen coordinates
        //Vector3 mousePos = Input.mousePosition;

        //// Convert screen coordinates to world coordinates
        //mousePos.z = 10f; // Set a small positive z-value for raycasting
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        //// Cast a ray from the mouse position
        //RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        //if (hit.collider != null)
        //{
        //    if (hit.collider.gameObject.CompareTag("UI"))
        //    {
        //        return false;
        //    }
        //    if (hit.collider.gameObject.CompareTag("ShopHex"))
        //    {
        //        return false;
        //    }
        //}
        //return true;
        #endregion
    }
    #region practice
    //void DrawCellOutline(Vector3 worldPos)
    //{
    //    // Get cell size (usually 1x1 unless you changed Tilemap cell size)
    //    Vector3 cellSize = hexTileMap.cellSize;

    //    // Four corners of the cell
    //    Vector3 bottomLeft = worldPos;
    //    Vector3 bottomRight = worldPos + new Vector3(cellSize.x, 0, 0);
    //    Vector3 topLeft = worldPos + new Vector3(0, cellSize.y, 0);
    //    Vector3 topRight = worldPos + new Vector3(cellSize.x, cellSize.y, 0);

    //    // Draw lines in the Scene view (visible in Play Mode)
    //    Debug.DrawLine(bottomLeft, bottomRight, Color.red, 1f);
    //    Debug.DrawLine(bottomRight, topRight, Color.red, 1f);
    //    Debug.DrawLine(topRight, topLeft, Color.red, 1f);
    //    Debug.DrawLine(topLeft, bottomLeft, Color.red, 1f);
    //}
    #endregion
}
