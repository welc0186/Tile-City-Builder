using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using Unity.Collections;

public class SpriteStack
{
    
    private GameObject[] _gameObjects;
    private RotatableSprite[] _rotatableSprites;

    // Sprite[0] is on the bottom
    public SpriteStack(GameObject parent, Sprite[] sprites, string sortingLayerName = "Default")
    {
        _gameObjects = new GameObject[sprites.Length];
        for(int i = 0; i < sprites.Length; i++)
        {
            if(sprites[i] == null)
                continue;
            
            var obj = new GameObject("SpriteLayer" + i);
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.parent = parent.transform;
            
            var renderer = obj.AddComponent<SpriteRenderer>();
            renderer.sprite = sprites[i];
            renderer.sortingLayerName = sortingLayerName;
            renderer.sortingOrder = i;

            _gameObjects[i] = obj;
        }    
    }

    public bool SwapSprite(Sprite newSprite, int layer = 0)
    {
        if(_gameObjects[layer] == null)
            return false;
        
        _gameObjects[layer].GetComponent<SpriteRenderer>().sprite = newSprite;
        return true;
    }

    public void ChangeLayer(string newLayer)
    {
        foreach(GameObject obj in _gameObjects)
        {
            obj.GetComponent<SpriteRenderer>().sortingLayerName = newLayer;
        }
    }

    public void RotateCW()
    {
        if(_rotatableSprites == null)
            return;
        
        for(int i = 0; i < _rotatableSprites.Length; i++)
        {
            foreach(RotatableSprite sprite in _rotatableSprites)
            {
                SwapSprite(sprite.Next(), i);
            }
        }
    }

    public void RotateCCW()
    {
        if(_rotatableSprites == null)
            return;
        
        for(int i = 0; i < _rotatableSprites.Length; i++)
        {
            foreach(RotatableSprite sprite in _rotatableSprites)
            {
                SwapSprite(sprite.Last(), i);
            }
        }
    }

    public void Destroy()
    {
        foreach(GameObject obj in _gameObjects)
        {
            GameObject.Destroy(obj);
        }
    }

}
