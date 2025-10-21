using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementManager : MonoBehaviour
{
    public Tilemap hexTileMap;
    public Tile selectedTile;
    public Grid grid;
    public GetTileType tileType;
    public string TileChoice;   //Place holder
    GlobalManager globalMan;


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
        //if (hexShop.canPlace == true)
        //{
        if (Input.GetMouseButtonDown(0) && globalMan.canPlace == true)
           {
         //   if(hexShop
                ////Get Tile For placement
                if (selectedTile == null)
                {
                    Debug.LogError("Get Tile Method returned null");
                }
                //selectedTile = tileType.GetTiles(shopMan.selectedTile);

                Debug.Log("Mouse clicked!");
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

                Vector3Int cellPos = hexTileMap.WorldToCell(mouseWorldPos);

                //Checks If
                if (!hexTileMap.HasTile(cellPos))
                {
                    Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);
                    PlaceTileAtCellCenter(cellPos);

                    //Draw debug square
                    //DrawCellOutline(cellWorldPos);
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
        //}
    }
    public void PlaceTileAtCellCenter(Vector3Int cellPos)
    {
        Vector3 cellWorldPos = hexTileMap.CellToWorld(cellPos);
        

        //Get grid cell center
        //Vector3Int cellPosition = grid.LocalToCell(mouseWorldPos);
        Vector3 cellCenter = grid.GetCellCenterLocal(cellPos);

        // Place Tile
        hexTileMap.SetTile(cellPos, selectedTile);
        //hexShop.canPlace = false;
        //Debug.Log("Can't place anymore!");
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
