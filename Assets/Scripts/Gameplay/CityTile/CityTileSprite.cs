using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTileSprite
{
    
    public SpriteStack SpriteStack { get; private set;}
    private SpriteLayer[] _spriteLayers;

    public CityTileSprite(GameObject parent, CityTileBlueprint blueprint)
    {
        _spriteLayers = blueprint.SpriteLayers;
        var stack = new Sprite[_spriteLayers.Length];
        for(int i = 0; i < _spriteLayers.Length; i++)
        {
            if(_spriteLayers[i].Layer[0] == null)
                continue;
            
            stack[i] = _spriteLayers[i].Layer[0];
        }
        SpriteStack = new SpriteStack(parent, stack);
    }

    public void Rotate(int rotateIndex)
    {
        for(int i = 0; i < _spriteLayers.Length; i++)
        {
            if (rotateIndex >= _spriteLayers[i].Layer.Length)
            {
                var maxIndex = _spriteLayers[i].Layer.Length - 1;
                SpriteStack.SwapSprite(_spriteLayers[i].Layer[maxIndex], i);
                continue;
            }
            SpriteStack.SwapSprite(_spriteLayers[i].Layer[rotateIndex], i);
        }
    }

}
