using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Item item = InventoryManager.Instance.GetSelectedItem();
        if (item != null)
        {
            if (item.type == Item.ItemType.Plant)
            {
                PlacementSystem.Instance.StartPlacement(item.ID);
               // PlacementSystem.Instance.tile = item.tile;
            }
            else if (item.type == Item.ItemType.Tool)
            {
                PlacementSystem.Instance.StartRemoving();
                /*PlacementSystem.Instance.CancelPreview();*/
            }
            else
            {
                PlacementSystem.Instance.StopPlacement();
            }
        }
        else
        {
            PlacementSystem.Instance.StopPlacement();
            return;
        }
        
    }
    
}
