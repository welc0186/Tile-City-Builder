using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLoopEventType
{
    START,
    TILE_DRAWN,
    TILE_PLACED,
    SCORED
}

public class GameLoopManager : MonoBehaviour
{

    [SerializeField] private GameEvent gameLoopEvent;
    private CityTileGridManager cityTileGridManager;
    private CityTileStack cityTileStack;

    void OnEnable()
    {
        InitCityTileGridManager();
        InitCityTileStack();
        InitGameLoop();
    }

    private void InitCityTileGridManager()
    {
        FindAndDestroy<CityTileGridManager>();
        GameObject resource = Resources.Load<GameObject>("Prefabs/CityTileGridManager");
        GameObject obj = GameObject.Instantiate(resource, Vector3.zero, Quaternion.identity);
        cityTileGridManager = obj.GetComponent<CityTileGridManager>();
    }

    private void InitCityTileStack()
    {
        cityTileStack = new CityTileStack();
    }

    private void InitGameLoop()
    {
        
    }

    void FindAndDestroy<T>()
    {
        if(GameObject.FindObjectOfType(typeof(T)))
        {
            GameObject[] objects = (GameObject[]) GameObject.FindObjectsOfType(typeof(T));
            foreach(GameObject gameObject in objects)
            {
                Destroy(gameObject);
            }
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
