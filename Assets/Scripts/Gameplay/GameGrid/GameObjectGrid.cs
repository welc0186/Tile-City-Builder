using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectGrid
{
    protected Dictionary<Vector2Int, GameObject> gridObjects;
    private List<Vector2Int> EmptyAdjacentSpaces;

    public GameObjectGrid() {
        gridObjects = new Dictionary<Vector2Int, GameObject>();
        EmptyAdjacentSpaces = new List<Vector2Int>();
    }

    public virtual void SetGridObject(GameObject gameObject, Vector2Int coords)
    {
        gridObjects.Add(coords, gameObject);
        Vector2Int[] scanCoords = new Vector2Int [] {
            coords + Vector2Int.left,
            coords + Vector2Int.up,
            coords + Vector2Int.right,
            coords + Vector2Int.down,
        };

        foreach(Vector2Int scanCoord in scanCoords)
        {
            if(GetGridObject(scanCoord) == null)
                EmptyAdjacentSpaces.Add(scanCoord);
        }
    }

    public GameObject GetGridObject(Vector2Int coords)
    {
        if(gridObjects.ContainsKey(coords))
            return gridObjects[coords];
        return null;
    }

    public Dictionary<Vector2Int, GameObject> GetNeighborObjects(GameObject centerObject)
    {
        Dictionary<Vector2Int, GameObject> ret = new Dictionary<Vector2Int, GameObject>();

        Vector2Int? centerCoord = WhereGridObject(centerObject);
        if(centerCoord == null)
            return ret;

        Vector2Int[] scanCoords = new Vector2Int [] {
            Vector2Int.left,
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
        };

        foreach(Vector2Int scanCoord in scanCoords)
        {
            if(GetGridObject(centerCoord.Value + scanCoord) != null)
            {
                ret.Add(scanCoord, GetGridObject(centerCoord.Value + scanCoord));
            }
        }

        return ret;
    }

    public Vector2Int? WhereGridObject(GameObject gameObject)
    {
        Vector2Int? ret = null;
        foreach(KeyValuePair<Vector2Int, GameObject> entry in gridObjects)
        {
            if(entry.Value == gameObject)
                ret = entry.Key;
        }
        return ret;
    }

    // TO-DO: Add empty corner spaces
    public List<Vector2Int> GetEmptyAdjacentSpaces(bool inclCorners = false)
    {
        return EmptyAdjacentSpaces;
    }

    public void Destroy()
    {
        foreach(KeyValuePair<Vector2Int, GameObject> entry in gridObjects)
        {
            GameObject.Destroy(entry.Value);
        }
        EmptyAdjacentSpaces = new List<Vector2Int>();
    }



}
