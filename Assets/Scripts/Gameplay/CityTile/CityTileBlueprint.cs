using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[System.Serializable]
public struct SpriteLayer
{
    public Sprite[] Layer;
}

[CreateAssetMenu(menuName = "TileBlueprint")]
public class CityTileBlueprint : ScriptableObject
{
    public string Name;
    public SpriteLayer[] SpriteLayers;
    public NetworkType[] EdgeTypes = new NetworkType[] {
        NetworkType.NONE,
        NetworkType.NONE,
        NetworkType.NONE,
        NetworkType.NONE
    };
    public string CityStructureName = "Default";

    private void OnValidate()
    {
        Name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
    }

}
