using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CityTilePlacerSpawner
{
    public static string filename = "Prefabs/CityTilePlacer";
    
    public static GameObject Spawn(object requester)
    {
        if(!(requester is CityTileStack))
            return null;

        CityTileStack stack = (CityTileStack) requester;
        GameObject newPlacer = GameObject.Instantiate(Resources.Load<GameObject>(filename), Vector3.zero, Quaternion.identity);
        newPlacer.GetComponent<CityTilePlacer>().TileStack = stack;
        return newPlacer;
    }
}

[RequireComponent(typeof(InputMB))]
public class CityTilePlacer : MonoBehaviour
{
    
    private CityTileGridManager gridManager;
    private InputMB input;
    private OpenTile openTile;
    public CityTile CityTile { get; private set; }
    [HideInInspector] public CityTileStack TileStack;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        input = GetComponent<InputMB>();
    }

    // Update is called once per frame
    void Update()
    {
        FindGridManager();
        DrawTile();
        HandleMouseMove();
        HandleAction();
        SnapToEmpty();
    }

    void DrawTile()
    {
        if(CityTile != null || gridManager == null)
            return;
        
        CityTile = TileStack.DrawTile()?.GetComponent<CityTile>();
        if(CityTile != null)
            gridManager.UpdateOpenTiles(CityTile);
    }

    void FindGridManager()
    {
        if(gridManager != null)
            return;
        if(GameObject.FindObjectOfType(typeof(CityTileGridManager)))
            gridManager = (CityTileGridManager) GameObject.FindObjectOfType(typeof(CityTileGridManager));
    }

    void HandleMouseMove()
    {
        if(CityTile == null)
            return;

        Vector3 tilePosition;
        Vector3 mousePos = input.MousePosition;
        ScanForEmptyTile(mousePos);
        if(openTile == null)
        {
            tilePosition = mousePos;
            Vector3 pixelPerfPos = PixelClamper.ClampVector(tilePosition, 64);
            CityTile.transform.position = pixelPerfPos;
        }
    }

    void HandleAction()
    {
        switch(input.InputAction)
        {
            case InputAction.PLACE:
                PlaceTile();
                return;
            case InputAction.ROTATE_CW:
                RotateTile(1);
                return;
            case InputAction.ROTATE_CCW:
                RotateTile(-1);
                return;
            default:
                break;
        }
    }

    void SnapToEmpty()
    {
        if(openTile == null || CityTile == null)
            return;
        
        CityTile.transform.position = openTile.transform.position;
        if(Array.IndexOf(openTile.ValidRotations, CityTile.rotationCW) < 0)
            RotateTile(1);
    }

    void ScanForEmptyTile(Vector3 position)
    {
        GameObject checkObject = Raycaster.FindObjectAt<OpenTile>(position);
        if(checkObject == null)
        {
            openTile = null;
            return;
        }
        if(checkObject.TryGetComponent(out OpenTile component))
            openTile = component;
    }

    void PlaceTile()
    {
        if(openTile == null || CityTile == null || gridManager == null)
            return;
        
        if(gridManager.PlaceTile(CityTile, openTile))
        {
            CityTile = null;
            Events.onTilePlaced?.Invoke(this.gameObject);
            GetComponent<AudioRequester>().RequestAudio();
        }
    }

    // positive is CW, negative is CCW
    void RotateTile(int dir)
    {
        if(CityTile == null)
            return;
        
        int[] valids;
        if(openTile != null)
        {
            valids = openTile.ValidRotations;
        } else {
            valids = new int[] {0, 1, 2, 3};
        }

        for(int tries = 0; tries < 4; tries++)
        {
            CityTile.Rotate(dir);
            if(Array.IndexOf(valids, CityTile.rotationCW) > -1)
                return;
        }
    }

}

public class OnTilePlacedEventArgs : EventArgs
{
    public GameObject Tile;
    public OnTilePlacedEventArgs(GameObject tile)
    {
        Tile = tile;
    }
}
