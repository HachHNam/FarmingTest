using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    [Header("Gameplay")] 
    public GameObject obj;
    public TileBase tile;
    public Vector2Int range;
    public ItemType type;
    [Header("UI")] 
    public bool stackable;
    [Header("Sprite")] 
    public Sprite _sprite; 
    
    public enum ItemType
    {
        Plant,
        Tool    
    }
    
}
