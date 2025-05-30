using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    public Image image;
    public Color selectedColor, notSelectedColor;

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
            draggableItem.parentAfterDrag = transform;

        }
        else
        {
            Transform currentItem = transform.GetChild(0);
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
            currentItem.SetParent(draggableItem.parentAfterDrag) ;
            draggableItem.parentAfterDrag = transform;
        }
    }
}
