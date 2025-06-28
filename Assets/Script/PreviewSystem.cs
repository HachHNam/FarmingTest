using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    
    private GameObject previewObject;
    public GameObject cellIndicator;
    public Color validColor, invalidColor;
    private Color _color;

    void Start()
    {
        cellIndicator.SetActive(false);
    }
    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        previewObject = Instantiate(prefab);
        PreparePreview(previewObject);
        PrepareCursor(size);
        cellIndicator.SetActive(true);
    }

    private void PrepareCursor(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            cellIndicator.transform.localScale = new Vector3(size.x * 1.5f, size.y*1.5f, 1);
        }
    }

    private void PreparePreview(GameObject previewObject)
    {
         SpriteRenderer spriteRenderer = previewObject.GetComponent<SpriteRenderer>();
         spriteRenderer.color = _color;
         spriteRenderer.sortingOrder += 1;
    }

    public void StopShowingPreview()
    {
        cellIndicator.SetActive(false);
        if (previewObject != null)
        {
            Destroy(previewObject);
        }
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        if (previewObject != null)
        {
            MovePreview(position);
        }
        MoveCursor(position);
        ApplyFeedback(validity); 
    }

    private void ApplyFeedback(bool validity)
    {
        _color = validity ? validColor : invalidColor;
       
    }

    void MoveCursor(Vector3 position)
    {
        cellIndicator.transform.position = position;
    }

    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = position;
    }

    public void StartShowingRemovePreview()
    {
        cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedback(false);
    }

}
