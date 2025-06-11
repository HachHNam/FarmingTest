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
                PlacementSystem.Instance.StartPlacing(item);
               // PlacementSystem.Instance.tile = item.tile;
            }
            else
            {
                PlacementSystem.Instance.StopPlacing();
                PlacementSystem.Instance.CancelPreview();
            }
        }
        else
        {
            PlacementSystem.Instance.StopPlacing();
            return;
        }
        
    }
    
}
