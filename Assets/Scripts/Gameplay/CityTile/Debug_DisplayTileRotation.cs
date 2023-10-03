using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CityTile))]
public class Debug_DisplayTileRotation : MonoBehaviour
{
    private CityTile cityTile;
    private float VERTICAL_OFFSET = 0.25f;

    void OnEnable()
    {
        cityTile = GetComponent<CityTile>();
    }
    
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        if(cityTile != null)
            Handles.Label(transform.position + Vector3.up * VERTICAL_OFFSET, cityTile.rotationCW.ToString());
        
    }


}
