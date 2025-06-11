using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingTile : MonoBehaviour
{
    [SerializeField] private int width,height;
    [SerializeField] private Tile tile_Prefab;
    [SerializeField] private float cellsize;
    [SerializeField] private float cellgap;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GenerateGrid()
    {
        for (int x =0 ; x<width; x++)
        {
            for (int y= 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tile_Prefab, new Vector3(transform.position.x + x*cellsize, transform.position.y), Quaternion.identity, this.transform);
                spawnedTile.name =  $"Tile {x} {y}";
                
            }
        }
    }
}
