using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private TileBase tile;
    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = mouseManager.GetSelectedMapPosition();
        if(mousePosition != Vector3.zero)
        {
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            mouseIndicator.transform.position = mousePosition;
            cellIndicator.transform.position = grid.GetCellCenterWorld(gridPosition);
            if(Input.GetMouseButtonDown(0))
            {
                tileMap.SetTile(gridPosition, tile);
            }
        }
       
        
    }

}
