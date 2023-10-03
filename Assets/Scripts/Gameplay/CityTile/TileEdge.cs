using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NetworkType
{
    NONE,
    ROAD,
    WATER,
    RAIL,
    AIR,
    POWER
}
[System.Serializable]
public class TileEdge
{
    
    public TileEdge EdgeMate { get; private set; }
    public NetworkType Type { get; private set; }

    public TileEdge(NetworkType type)
    {
        Type = type;
    }

    public bool PlaceMatch(TileEdge checkEdge)
    {
        // if they match types or either edge is a water and the other is none (grass)
        if(Type == checkEdge.Type || 
            Type == NetworkType.NONE && checkEdge.Type == NetworkType.WATER ||
            Type == NetworkType.WATER && checkEdge.Type == NetworkType.NONE)
            return true;
        return false;
    }

    public bool LinkMatch(TileEdge checkEdge)
    {
        // Link if they share the same network except NetworkType.NONE
        if(Type == NetworkType.NONE)
            return false;
        if(Type == checkEdge.Type)
            return true;
        return false;
    }

}
