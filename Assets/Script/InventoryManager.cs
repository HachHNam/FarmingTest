using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public InventorySlot[] inventorySlots;
    int selectedSlot = -1;
    Item currentItem;
    
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < inventorySlots.Length)
            {
                ChangeSelectedSlot(number -1);
            }
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnItemInSlot(item, slot);
                return;
            }
        }
    }

    public void SpawnItemInSlot(Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(item.obj, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void ChangeSelectedSlot(int slotNumber)
    {
        
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
           // PlacementSystem.Instance.StopPlacement();
        }
        if (selectedSlot != slotNumber)
        {
            inventorySlots[slotNumber].Select();
            selectedSlot = slotNumber;
            //currentItem = GetSelectedItem();
           // PlacementSystem.Instance.StartPlacement(currentItem.ID);
        }
        else
        {
            inventorySlots[selectedSlot].Deselect();
            selectedSlot = -1;
            //PlacementSystem.Instance.StopPlacement();
        }
    }

    public void Cancel()
    {
        inventorySlots[selectedSlot].Deselect();
    }
   
    public Item GetSelectedItem()
    {
        if (selectedSlot >= 0)
        {
            InventorySlot slot = inventorySlots[selectedSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                return itemInSlot.item;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }

    }
}
