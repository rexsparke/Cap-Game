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
    //[SerializeField]
    //private LayerMask m_groundMask;
    public Tilemap hexTileMap;
    public Tile selectedTile;

    void Update()
    {
        //raycast from from camera

        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        //Vector2 mousePosition = Input.mousePosition;
        //Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        //RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = hexTileMap.WorldToCell(mouseWorldPos);

            if (hexTileMap.HasTile(cellPos))
            {
                hexTileMap.SetTile(cellPos,selectedTile);
            }
        }
    }
}
