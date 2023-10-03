using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CityTileSpawner
{
    public static GameObject Spawn(CityTileBlueprint blueprint, Vector3 location = default(Vector3))
    {
        GameObject newTile = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/CityTile"), location, Quaternion.identity);
        newTile.GetComponent<CityTile>().Initialize(blueprint);
        return newTile;
    }
}

public class CityTile : MonoBehaviour
{
    
    public CityTileBlueprint Blueprint { get; private set; }
    
    public int rotationCW { get; private set; }
    public TileEdge[] Edges { get; private set; }
    private CityTileSprite _cityTileSprite;
    private SpriteRenderer _networkSprite;
    public bool Placed { get; private set; }
    public CityStructure Structure { get; private set; }

    public void Initialize(CityTileBlueprint blueprint)
    {
        if(Blueprint != null)
            return;

        Blueprint = blueprint;
        _cityTileSprite = new CityTileSprite(this.gameObject, blueprint);
        _cityTileSprite.SpriteStack.ChangeLayer("ActiveTiles");
        rotationCW = 0;
        InitEdges();
        Rotate(0);
    }

    void OnDestroy()
    {
        _cityTileSprite.SpriteStack.Destroy();
    }

    void InitEdges()
    {
        Edges = new TileEdge[4];
        for(int i = 0; i < 4; i++)
        {
            Edges[i] = new TileEdge(Blueprint.EdgeTypes[i]);
        }
    }
    
    public void Rotate(int dir = 1)
    {
        if(dir > 0)
        {
            rotationCW++;
            if(rotationCW > 3)
                rotationCW = 0;
        }
        if(dir < 0)
        {
            rotationCW--;
            if(rotationCW < 0)
                rotationCW = 3;
        }
        _cityTileSprite.Rotate(rotationCW);
    }

    public bool Place()
    {
        if(Placed)
            return false;
        
        Placed = true;
        _cityTileSprite.SpriteStack.ChangeLayer("PlacedTiles");
        Structure = new CityStructure(this, Blueprint.CityStructureName);
        return true;
    }

    // Returns the edge object of the cardinal direction (up, right, down, left).
    // Providing rotation overrides current rotation for calculation
    public TileEdge GetEdgeFromCardinal(Vector2Int dir, int rotation = -1)
    {
        int[,] edgeIndex = new int[4, 4] {
            {0, 3, 2, 1},
            {1, 0, 3, 2},
            {2, 1, 0, 3},
            {3, 2, 1, 0}
        };

        int x;
        int y;
        switch(dir)
        {
            case Vector2Int v when v.Equals(Vector2Int.up):
                x = 0;
                break;
            case Vector2Int v when v.Equals(Vector2Int.right):
                x = 1;
                break;
            case Vector2Int v when v.Equals(Vector2Int.down):
                x = 2;
                break;
            case Vector2Int v when v.Equals(Vector2Int.left):
                x = 3;
                break;
            default:
                return null;
        }

        if(rotation < 0 || rotation > 3)
        {
            y = rotationCW;
        } else
        {
            y = rotation;
        }
        return Edges[edgeIndex[x,y]];
    }

    public void DebugPrintCardinalEdges()
    {
        Vector2Int[] dirs = new Vector2Int[] {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left,
        };

        foreach(Vector2Int dir in dirs)
        {
            Debug.Log("Dir: " + dir + "Edge: " + GetEdgeFromCardinal(dir).Type);
        }
    }

    
}
