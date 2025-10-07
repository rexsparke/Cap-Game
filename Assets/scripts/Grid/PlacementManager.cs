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


    void Start()
    {
       // Grid grid = transform.GetComponent<Grid>();

        if (grid != null)
        {
            Debug.Log("Grid is not their");
        }
        else
        {
            Debug.LogError("Grid is their");
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
        //raycast from from camera

        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        //Vector2 mousePosition = Input.mousePosition;
        //Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        //RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked!");
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                    new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));

            Vector3Int cellPos = hexTileMap.WorldToCell(mouseWorldPos);
            Vector3 cellWorldPos = hexTileMap.CellToWorld(cellPos);

            Debug.Log("Mouse world pos: " + mouseWorldPos + " | Cell pos: " + cellPos);

            //Get grid cell center
            Vector3Int cellPosition = grid.LocalToCell(mouseWorldPos);
            Vector3 cellCenter = grid.GetCellCenterLocal(cellPosition);

            Vector3Int cellCenterPos= Vector3Int.CeilToInt(cellCenter);

            // Place Tile
            hexTileMap.SetTile(cellCenterPos, selectedTile);
            //hexTileMap.SetTile(cellPos, selectedTile);

            //Draw debug square
            //DrawCellOutline(cellWorldPos);

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
}
