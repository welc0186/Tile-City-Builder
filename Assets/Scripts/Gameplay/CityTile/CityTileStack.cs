using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTileStack : MonoBehaviour
{
    private const int MAX_TILES = 100;
    private List<CityTileBlueprint> cityTiles;
    private List<GameObject> spawnedTiles;
    private CityTilePlacer cityTilePlacer;
    private TileBlueprintManager tileBlueprintManager;

    void Start()
    {
        tileBlueprintManager = new TileBlueprintManager();
        cityTiles = new List<CityTileBlueprint>();
        for(int i = 0; i < MAX_TILES; i++)
        {
            cityTiles.Add(tileBlueprintManager.GetRandomBlueprint());
        }
        spawnedTiles = new List<GameObject>();
        FindOrSpawnPlacer();
    }

    public GameObject DrawTile(Vector3 location = default(Vector3))
    {
        if(cityTiles.Count <= 0)
            return null;
        
        GameObject newTile = CityTileSpawner.Spawn(NextTile(), location);
        spawnedTiles.Add(newTile);
        cityTiles.RemoveAt(0);
        return newTile;
    }

    // TO-DO: Notify that the game should be over if no more city tiles in stack
    public CityTileBlueprint NextTile()
    {
        if(cityTiles.Count <= 0)
            return null;
        
        return cityTiles[0];
    }

    void FindOrSpawnPlacer()
    {
        if(cityTilePlacer != null)
            return;
        
        if(GameObject.FindObjectOfType(typeof(CityTilePlacer)))
        {
            cityTilePlacer = (CityTilePlacer) GameObject.FindObjectOfType(typeof(CityTilePlacer));
            cityTilePlacer.TileStack = this;
            return;
        }

        cityTilePlacer = CityTilePlacerSpawner.Spawn(this).GetComponent<CityTilePlacer>();

    }

}
