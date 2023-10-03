using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CityTileStack : MonoBehaviour
{
    
    [SerializeField] private List<CityTileBlueprint> blueprints;
    private CityTileStack cityTileStack;
    private int numUpdates;

    void OnEnable()
    {
        cityTileStack = new CityTileStack();
    }

    /*
    void Update()
    {
        if(numUpdates == 10)
            return;
        
        Vector3 spawnPoint = Vector3.zero + numUpdates * Vector3.one;
        cityTileStack.DrawTile(spawnPoint);
        numUpdates++;
    }
    */

}
