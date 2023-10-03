using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CityTile))]
[RequireComponent(typeof(AudioRequester))]
public class CityTileAudio : MonoBehaviour
{
    
    private CityTile cityTile;
    [SerializeField] private AudioRequester clickAudio;
    private bool tilePlaced;
    
    void Awake()
    {
        cityTile = GetComponent<CityTile>();
        clickAudio = GetComponent<AudioRequester>();
        tilePlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cityTile.Placed && !tilePlaced)
        {
            Debug.Log("Requesting audio\n");
            clickAudio.RequestAudio();
            tilePlaced = true;
        }
    }
}
