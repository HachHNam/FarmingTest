using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementSystem : Singleton<PlacementSystem>
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject tileMapGO;
    [SerializeField] private TileBase occupyTile;
    private Tilemap tile_Map;
    public GameObject[] farmingGrid;
    public Color previewColor;
    public bool canPreview = true;
    private GameObject previewObj;
    List<Vector3Int> occupied = new List<Vector3Int>();
    [SerializeField] private ObjectsDatabaseSO database;
    [SerializeField] private PreviewSystem preview;
    private GridData plantData;
    private Vector3Int lastDetectedPosition =  Vector3Int.zero;
    public ObjectPlacer objectPlacer;
    private IBuildingState buildingState;
    private void Start()
    {
        tile_Map = tileMapGO.GetComponent<Tilemap>();
        StopPlacement();
        plantData = new GridData();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(true);
        }
        tileMapGO.SetActive(true);
        buildingState = new PlacementState(ID, grid, preview, database, plantData, objectPlacer);
        mouseManager.OnClicked += PlaceStructure;
        mouseManager.OnExit += StopPlacement;
       

    }
    public void StartRemoving()
    {
        StopPlacement();
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(true);
        }
        tileMapGO.SetActive(true);
        buildingState = new RemovingState(grid, preview, plantData, objectPlacer);
        mouseManager.OnClicked += PlaceStructure;
        mouseManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (mouseManager.IsPointerOverUI())
        {
            return;
        }

        Vector3 mousePosition = mouseManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        buildingState.OnAction(gridPosition);
    }   

    // private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    // {
    //     GridData selectedData = plantData;
    //     return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    // }

    public void StopPlacement()
    {
        if (buildingState == null)
        {
            return;
        }
        for (int i = 0; i < farmingGrid.Length; i++)
        {
            farmingGrid[i].SetActive(false);
        }
        tileMapGO.SetActive(false);
        buildingState.EndState();
        mouseManager.OnClicked -= PlaceStructure;
        mouseManager.OnExit -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;
        buildingState =  null;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingState == null)
        {
            return;
        }
        Vector3 mousePosition = mouseManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        if (lastDetectedPosition != gridPosition)
        {
            buildingState.UpdateState(gridPosition);
            lastDetectedPosition = gridPosition;
        }
       
        //cellSprite.transform.position = grid.GetCellCenterWorld(gridPosition);
    }
}



