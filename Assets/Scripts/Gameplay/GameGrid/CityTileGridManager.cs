using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityTileGridManager : MonoBehaviour
{
    public CityTileGrid Grid { get; private set; }
    private Dictionary<OpenTile, Vector2Int> spawnedOpenTiles;
    public Dictionary<Vector2Int, List<CityStructure>> AdjacencyFlags { get; private set;}

    void Start()
    {
        AdjacencyFlags = new Dictionary<Vector2Int, List<CityStructure>>();
        
        Grid = new CityTileGrid(Vector3.zero, 1);
        var tileBluePrintManager = new TileBlueprintManager();
        var originBluePrint = tileBluePrintManager.GetBlueprintByName("BlankGround");
        GameObject originTile = CityTileSpawner.Spawn(originBluePrint, Vector3.zero);
        Grid.PlaceTile(originTile, Vector2Int.zero);
    }

    public bool PlaceTile(CityTile cityTile, OpenTile openTile)
    {
        Vector2Int? coords = WhereOpenTile(openTile);
        if(coords == null)
            return false;

        Grid.PlaceTile(cityTile.gameObject, coords.Value);
        DestroyOpenTiles();
        cityTile.Place();
        return true;
    }

    Vector2Int? WhereOpenTile(OpenTile openTile)
    {
        if(spawnedOpenTiles == null)
            return null;
        
        foreach(KeyValuePair<OpenTile, Vector2Int> entry in spawnedOpenTiles)
        {
            if(entry.Key == openTile)
                return entry.Value;
        }
        return null;
    }

    void DestroyOpenTiles()
    {
        foreach(KeyValuePair<OpenTile, Vector2Int> entry in spawnedOpenTiles)
            Destroy(entry.Key.gameObject);
        spawnedOpenTiles = null;
    }

    public void UpdateOpenTiles(CityTile cityTile)
    {        
        if(spawnedOpenTiles != null)
            DestroyOpenTiles();

        if(cityTile == null)
            return;
        
        spawnedOpenTiles = new Dictionary<OpenTile, Vector2Int>();
        
        foreach(Vector2Int coord in Grid.EmptySpaces)
        {
            int[] validRotations = GetValidRotations(coord, cityTile);
            if(validRotations == null)
                continue;
            Vector3 worldCoords = Grid.GridToWorld(coord);
            OpenTile spawnedEmptyTile = OpenTileSpawner.Spawn(worldCoords, validRotations).GetComponent<OpenTile>();
            spawnedOpenTiles.Add(spawnedEmptyTile, coord);
        }
    }

    public void AddAdjacencyFlag(Vector2Int coord, CityStructure structure)
    {
        // List should already be initialized if it contains the coordinates
        if(AdjacencyFlags.ContainsKey(coord))
        {
            AdjacencyFlags[coord].Add(structure);
            return;
        }
        
        List<CityStructure> structures = new List<CityStructure>() { structure };
        AdjacencyFlags.Add(coord, structures);
    }

    int[] GetValidRotations(Vector2Int coord, CityTile tile)
    {
        List<int> ret = new List<int>() {0, 1, 2, 3};
        for(int i = 0; i < 4; i++)
        {
            if(!ValidPlace(coord, tile, i))
                ret.Remove(i);
        }
        if(ret.Count == 0)
            return null;

        return ret.ToArray();
    }

    // Checks the Grid around 'tile' to see if it is a valid placement given its rotation
    bool ValidPlace(Vector2Int coord, CityTile tile, int rotation)
    {
        Vector2Int[] checkCoords = new Vector2Int[] {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };

        foreach(Vector2Int checkCoord in checkCoords)
        {
            GameObject checkTileObj = Grid.GetGridObject(coord + checkCoord);
            if(checkTileObj == null)
                continue;
            CityTile checkTile = checkTileObj.GetComponent<CityTile>();

            TileEdge localEdge = tile.GetEdgeFromCardinal(checkCoord, rotation);
            TileEdge checkEdge = checkTile.GetEdgeFromCardinal(checkCoord * -1);
            if(!localEdge.PlaceMatch(checkEdge))
                return false;
        }
        return true;
    }


}
