using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementSystem : Singleton<PlacementSystem>
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap tileMap;
    public GameObject[] farmingGrid;
    public TileBase tile;
    private SpriteRenderer cellSprite;

    private void Start()
    {
        cellSprite = cellIndicator.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlacing()
    {
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(true);
        }
        Vector3 mousePosition = mouseManager.GetSelectedMapPosition();
        if(mousePosition != Vector3.zero)
        {
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            if (!tileMap.HasTile(gridPosition))
            {
                mouseIndicator.transform.position = mousePosition;
                cellIndicator.transform.position = grid.GetCellCenterWorld(gridPosition);
                cellSprite.enabled = true;
                if(Input.GetMouseButtonDown(0))
                {
                    tileMap.SetTile(gridPosition, tile);
                }
            }
            else
            {
                cellSprite.enabled = false;
            }
            
        }
    }

    public void StopPlacing()
    {
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(false);
        }
        cellSprite.enabled = false;
    }

}
