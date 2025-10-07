using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementManager : MonoBehaviour
{
    //[SerializeField]
    //private Grid m_hexGrid;
    //[SerializeField]
    //private GameObject m_hexLandPreFab;
    public Tilemap hexTileMap;
    public Tile selectedTile;
    public Grid grid;
    public GetTileType tileType;
    public string TileChoice;   //Place holder


    void Start()
    {

        if (grid != null)
        {
            Debug.Log("Grid is not their");
        }
        else
        {
            Debug.Log("Grid is their");
        }
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
        if (Input.GetMouseButtonDown(0))
        {
            ////Get Tile For placement
            //selectedTile = tileType.GetTile(TileChoice);
            //if(selectedTile == null)
            //{
            //    Debug.LogError("Get Tile Method returned null");
            //}
            Debug.Log("Mouse clicked!");
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

            Vector3Int cellPos = hexTileMap.WorldToCell(mouseWorldPos);
            if (!hexTileMap.HasTile(cellPos))
            { 
            Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);
            PlaceTileAtCellCenter(cellPos);
            //hexTileMap.SetTile(cellPos, selectedTile);

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
    }
    public void PlaceTileAtCellCenter(Vector3Int cellPos)
    {
        Vector3 cellWorldPos = hexTileMap.CellToWorld(cellPos);
        

        //Get grid cell center
        //Vector3Int cellPosition = grid.LocalToCell(mouseWorldPos);
        Vector3 cellCenter = grid.GetCellCenterLocal(cellPos);

        // Place Tile
        hexTileMap.SetTile(cellPos, selectedTile);
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
