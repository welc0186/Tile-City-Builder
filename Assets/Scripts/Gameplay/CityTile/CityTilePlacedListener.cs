using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTilePlacedListener : MonoBehaviour
{
    void Start()
    {
        Events.onTilePlaced.Subscribe(OnTilePlaced);
    }

    void OnDestroy()
    {
        Events.onTilePlaced.Unsubscribe(OnTilePlaced);
    }

    private void OnTilePlaced(GameObject tile)
    {
        Debug.Log("Tile placed!\n");
    }
}
