using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OpenTileSpawner
{

    public static GameObject Spawn(Vector3 coords, int[] validRotations)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/OpenTile");
        GameObject spawnedObj = GameObject.Instantiate(prefab, coords, Quaternion.identity);
        spawnedObj.GetComponent<OpenTile>().ValidRotations = validRotations;
        return spawnedObj;
    }

}


public class OpenTile : MonoBehaviour
{
    
    public int[] ValidRotations;
    public CityTile PlacedTile { get; private set; }
    [HideInInspector] public CityTileGrid Grid;

    public CityTileGrid PlaceTile(CityTile tile)
    {
        if(PlacedTile != null)
            return null;
        PlacedTile = tile;
        return Grid;
    }

}
