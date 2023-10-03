using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBlueprintManager
{
    
    private List<CityTileBlueprint> blueprints;

    public TileBlueprintManager()
    {
        blueprints = new List<CityTileBlueprint>();
        LoadBlueprints();
    }

    public void LoadBlueprints()
    {
        CityTileBlueprint[] objs = Resources.LoadAll<CityTileBlueprint>("ScriptableObjects/TileBlueprints");
        foreach(CityTileBlueprint obj in objs)
        {
            if (blueprints.Contains(obj))
                continue;
            blueprints.Add(obj);
            Resources.UnloadAsset(obj);
        }
    }

    public CityTileBlueprint GetRandomBlueprint()
    {
        if(blueprints.Count < 1)
            return null;
        
        int rand = UnityEngine.Random.Range(0, blueprints.Count);
        return blueprints[rand];
    }

    public CityTileBlueprint GetBlueprintByName(string name)
    {
        foreach(CityTileBlueprint blueprint in blueprints)
        {
            if(blueprint.Name == name)
                return blueprint;
        }
        return null;
    }

}
