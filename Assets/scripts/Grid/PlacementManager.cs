using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementManager : MonoBehaviour
{
    public Tilemap hexTileMap;
    public Tile selectedTile;
    public Grid grid;
    public GetTileType tileType;

    public List<GameObject> TileList = new List<GameObject>();
    GlobalManager globalMan;
    private GameObject selectedObjTile;
    ShopManager shopMan;


    void Start()
    {
        globalMan = GetComponent<GlobalManager>();
        //if(globalMan.canPlace == false)
        //{
        //    Debug.LogError("CanPlay is false");
        //}
        //else
        //{
        //    Debug.Log("Can place is not null");
        //}
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
        if (Input.GetMouseButtonDown(0))
           {
         //   if(hexShop
                ////Get Tile For placement
                if (selectedTile == null)
                {
                    Debug.LogError("Get Tile Method returned null");
                }
                //Get world position of mouse
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

                Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + GetCelPosition());

                //Returns the integer coordinates of the cell on the tilemap or grid if i tried.
                Vector3Int cellPos = hexTileMap.WorldToCell(mouseWorldPos);
                Debug.Log("Mouse clicked!");
                //Vector3Int cellPos = GetCelPosition();
                //Checks If
                if (!hexTileMap.HasTile(cellPos))
                {
                    //Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);
                    PlaceObjectAtCellCenter(cellPos);
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
        }
    }
    public Vector3Int GetCelPosition()
    {
        //Get world position of mouse
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

        //Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + GetCelPosition());

        //Returns the integer coordinates of the cell on the tilemap or grid if i tried.
        return hexTileMap.WorldToCell(mouseWorldPos);
    }
    public void PlaceObjectAtCellCenter(Vector3Int cellPos)
    {
        //Vector3 cellWorldPos = hexTileMap.CellToWorld(cellPos);
        //Vector3Int cellPosition = grid.LocalToCell(mouseWorldPos);

        //Get grid cell center
        Vector3 cellCenter = grid.GetCellCenterLocal(cellPos);

        //Get New Tile From Shop
        selectedObjTile = GetGameObject(shopMan.selectedTile);

        // Place Tile
        selectedObjTile.transform.position = new Vector2(cellCenter.x,cellCenter.y);
        hexTileMap.SetTile(cellPos, selectedTile);
        globalMan.canPlace = false;
        Debug.Log("Can't place anymore!");
    }
    public GameObject GetGameObject(int selectedTile)
    {
        GameObject objTile = TileList[selectedTile];
        return objTile;
    }
    public bool CheckShopPlaceMent(Vector3Int cellPosition)
    {
        int switchCheck = cellPosition.x;
        switch(switchCheck)
        {
            case 6:
                return false;
            case 7:
                return false;
            case 8:
                return false;
            default:
                return true;
        }
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
