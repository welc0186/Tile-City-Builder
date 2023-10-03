using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTileGrid : GameObjectGrid
{
    
    private Vector3 origin;
    private float tileSize;
    public List<Vector2Int> EmptySpaces { get; private set; }

    public CityTileGrid(Vector3 origin, float tileSize) : base ()
    {
        this.origin = origin;
        this.tileSize = tileSize;
        EmptySpaces = new List<Vector2Int>();
    }

    public Vector3 GridToWorld(Vector2Int gridCoords)
    {
        float x = origin.x + tileSize * gridCoords.x;
        float y = origin.y + tileSize * gridCoords.y;
        float z = origin.z;
        return new Vector3(x, y, z);
    }

    public void PlaceTile(GameObject gameObject, Vector2Int coords)
    {
        if(GetGridObject(coords) != null)
            return;
        
        SetGridObject(gameObject, coords);
        EmptySpaces.Remove(coords);

        Vector2Int[] checkCoords = new Vector2Int[] {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };

        foreach(Vector2Int checkCoord in checkCoords)
        {
            if(GetGridObject(coords + checkCoord) == null)
                EmptySpaces.Add(coords + checkCoord);
        }
    }
}
