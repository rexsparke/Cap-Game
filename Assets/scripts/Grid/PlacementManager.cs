using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField]
    private Grid m_hexGrid;
    [SerializeField]
    private GameObject m_hexLandPreFab;
    [SerializeField]
    private LayerMask m_groundMask;

    void Update()
    {
        //raycast from from camera

        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Check if hit layer is in the ground mask
            if((m_groundMask.value & (1 << hit.collider.gameObject.layer)) == 0)
            {
                return;
            }

            //Calculate hex grid position and move preview (calculate cell world position)
            Vector3Int cellPosition = m_hexGrid.WorldToCell(hit.point);

            //Calculate center of cell
            Vector3 cellPositionWorld = m_hexGrid.GetCellCenterWorld(cellPosition);
            // = m_hexGrid.CellToWorld(cellPosition);

            //place hex tile
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(m_hexLandPreFab, cellPositionWorld, Quaternion.identity);
            }
        }
    }
}
