using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CityStructureType
{
    NONE,
    RESIDENTIAL,
    COMMERCIAL,
    INDUSTRIAL
}

public class CityStructureInfo
{
    
    public string Name;
    public string Description;
    public CityStructureType Type;
    public int NetworkRange;
    public Dictionary<CityStructureType, int> NetworkScore;
    public int AdjacentRange;
    public Dictionary<CityStructureType, int> AdjacentScore;
}

public static class CityStructureData
{
    public static CityStructureInfo GetByName(string name = null)
    {
        if(name == null)
        {
            return Structures.Find(
                s => s.Name == "Default"
            );
        }
        
        return Structures.Find(
            s => s.Name == name
        );
    }
    
    public static readonly List<CityStructureInfo> Structures = new List<CityStructureInfo>() {
        new CityStructureInfo() {
            Name = "Default",
            Description = "No structure here",
            Type = CityStructureType.NONE,
            NetworkRange = 0,
            NetworkScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,    0},
                { CityStructureType.COMMERCIAL,     0},
                { CityStructureType.INDUSTRIAL,     0}
            },
            AdjacentRange = 0,
            AdjacentScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,    0},
                { CityStructureType.COMMERCIAL,     0},
                { CityStructureType.INDUSTRIAL,     0}
            }    
        },
        new CityStructureInfo() {
            Name = "House",
            Description = "A Simple House",
            Type = CityStructureType.RESIDENTIAL,
            NetworkRange = 10,
            NetworkScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,    0},
                { CityStructureType.COMMERCIAL,     1},
                { CityStructureType.INDUSTRIAL,     1}
            },
            AdjacentRange = 0,
            AdjacentScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,    0},
                { CityStructureType.COMMERCIAL,     0},
                { CityStructureType.INDUSTRIAL,     0}
            }    
    
        },
        new CityStructureInfo() {
            Name = "Corner Shop",
            Description = "Cuuute",
            Type = CityStructureType.COMMERCIAL,
            NetworkRange = 10,
            NetworkScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,   10},
                { CityStructureType.COMMERCIAL,     0},
                { CityStructureType.INDUSTRIAL,    10}
            },
            AdjacentRange = 1,
            AdjacentScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,   -1},
                { CityStructureType.COMMERCIAL,    -5},
                { CityStructureType.INDUSTRIAL,     0}
            }    
    
        },
        new CityStructureInfo() {
            Name = "Factory",
            Description = "Makes Stuff",
            Type = CityStructureType.INDUSTRIAL,
            NetworkRange = 10,
            NetworkScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,    0},
                { CityStructureType.COMMERCIAL,    10},
                { CityStructureType.INDUSTRIAL,    10}
            },
            AdjacentRange = 1,
            AdjacentScore = new Dictionary<CityStructureType, int> {
                { CityStructureType.NONE,           0},
                { CityStructureType.RESIDENTIAL,  -10},
                { CityStructureType.COMMERCIAL,   -10},
                { CityStructureType.INDUSTRIAL,     0}
            }    
    
        },
    };
}
