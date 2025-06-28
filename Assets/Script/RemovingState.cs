using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    private Grid grid;
    PreviewSystem previewSystem;
    GridData plantData;
    ObjectPlacer objectPlacer;

    public RemovingState(Grid grid, PreviewSystem previewSystem, GridData plantData, ObjectPlacer objectPlacer)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.plantData = plantData;
        this.objectPlacer = objectPlacer;
        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if (plantData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = plantData;
        }

        if (selectedData == null)
        {
            //invalid placement sound
        }
        else
        {
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
            {
                return;
            }
            selectedData.RemoveObjectAt(gridPosition);
            objectPlacer.RemoveObjectAt(gameObjectIndex);
        }
        Vector3 cellPosition = grid.GetCellCenterWorld(gridPosition);
        previewSystem.UpdatePosition(cellPosition, CheckIfPositionIsValid(gridPosition));
    }

    private bool CheckIfPositionIsValid(Vector3Int gridPosition)
    {
        return !plantData.CanPlaceObjectAt(gridPosition, Vector2Int.one);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfPositionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.GetCellCenterWorld(gridPosition), validity);
    }
}
