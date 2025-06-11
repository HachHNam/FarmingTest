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
    [SerializeField] private GameObject tileMapGO;
    [SerializeField] private TileBase occupyTile;
    private Tilemap tile_Map;
    public GameObject[] farmingGrid;
    public Color previewColor;
    public bool canPreview = true;
    //public TileBase tile;
    private GameObject cellSprite;
    public GameObject previewObj;
    //public GameObject testPref;
    List<Vector3Int> occupied = new List<Vector3Int>();



    private void Start()
    {
        tile_Map = tileMapGO.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartPlacing(Item item)
    {
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(true);
        }
        tileMapGO.SetActive(true);
        Vector3 mousePosition = mouseManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        if(mousePosition != Vector3.zero &&!occupied.Contains(gridPosition))
        {
          if(canPreview)
           {
                canPreview = false;
                PreparePreview(item);
           }
          UpdatePreview(gridPosition);
          if(Input.GetMouseButtonDown(0))
           {
                Instantiate(item.obj, grid.GetCellCenterWorld(gridPosition), Quaternion.identity);
                tile_Map.SetTile(gridPosition, occupyTile);
                occupied.Add(gridPosition);
                CancelPreview();
           }
        }
        else
        {
           CancelPreview();
        }
    }

    public void StopPlacing()
    {
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(false);
        }
        CancelPreview();
        tileMapGO.SetActive(false);
    }

    public void PreparePreview(Item item)
    {
        CancelPreview();
        cellSprite = Instantiate(cellIndicator);
        previewObj = Instantiate(item.obj);  
    }


    public void UpdatePreview(Vector3Int gridPosition)
    {
        SpriteRenderer sr = previewObj.GetComponent<SpriteRenderer>();
        sr.color = previewColor;
        cellSprite.transform.position = grid.GetCellCenterWorld(gridPosition);
        previewObj.transform.position = grid.GetCellCenterWorld(gridPosition);
        
    }

    public void CancelPreview()
    {
        Destroy(previewObj);
        Destroy(cellSprite);
        canPreview = true;
    }
}

