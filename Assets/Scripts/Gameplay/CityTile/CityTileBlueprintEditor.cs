using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CityTileBlueprint))]
public class CityTileBlueprintEditor : Editor
{
    
    CityTileBlueprint blueprint;

    private void OnEnable()
    {
        blueprint = target as CityTileBlueprint;
    }
    
    public override void OnInspectorGUI()
    {
        //Draw whatever we already have in SO definition
        base.OnInspectorGUI();

        if(blueprint.SpriteLayers == null || blueprint.SpriteLayers.Length < 0)
            return;


        // TODO: This was causing Unity to crash from some reason.
        // for(int i = 0; i < blueprint.SpriteLayers.Length; i++)
        // {
        //     if (blueprint.SpriteLayers[i].Layer.Length < 1)
        //         continue;
        //     if (blueprint.SpriteLayers[i].Layer[0] == null)
        //         continue;
            

        //     //Convert the sprite (see SO script) to Texture
        //     Texture2D texture = AssetPreview.GetAssetPreview(blueprint.SpriteLayers[i].Layer[0]);
            
        //     //We create empty space 80x80 (you may need to tweak it to scale better your sprite
        //     //This allows us to place the image JUST UNDER our default inspector
        //     GUILayout.Label(texture, GUILayout.Height(80), GUILayout.Width(80));
        //     //GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
        // }
    }
}
