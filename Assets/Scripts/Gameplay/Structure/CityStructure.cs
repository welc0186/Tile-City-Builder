using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityStructure : GraphVertex
{
    
    private CityTile _parentTile;
    public CityTile ParentTile
    {
        get { return _parentTile; }
    }
    public CityStructureInfo Info { get; private set; }

    public CityStructure(CityTile parent, string name) : base ()
    {
        _parentTile = parent;
        Info = CityStructureData.GetByName(name);
        if(Info == null)
            Info = CityStructureData.GetByName();  // Default tile
        InitStructure();
    }

    public override void AddNeighbor(GraphVertex neighbor, int edgeWeight = 1)
    {
        base.AddNeighbor(neighbor, edgeWeight);
    }

    void InitStructure()
    {
        if(!GameObject.FindObjectOfType(typeof(CityTileGridManager)))
        {
            Debug.Log("Couldn't find City Tile Grid Manager");
            return;
        }
        CityTileGridManager gridManager = (CityTileGridManager) GameObject.FindObjectOfType(typeof(CityTileGridManager));
        Dictionary<Vector2Int, GameObject> neighborTiles = gridManager.Grid.GetNeighborObjects(_parentTile.gameObject);
        foreach(KeyValuePair<Vector2Int, GameObject> entry in neighborTiles)
        {
            TryLinkStructure(entry.Value.GetComponent<CityTile>(), entry.Key);
        }
        SearchNetwork();
    }

    bool TryLinkStructure(CityTile linkTile, Vector2Int tilePos)
    {
        TileEdge parentEdge = _parentTile.GetEdgeFromCardinal(tilePos);
        TileEdge linkEdge = linkTile.GetEdgeFromCardinal(tilePos * -1);
        if(!parentEdge.LinkMatch(linkEdge))
            return false;
        linkTile.Structure.AddNeighbor(this);
        return true;
    }

    void SearchNetwork()
    {
        List<GraphVertex> vertices = Graphs.GetAllWithinDistance(this, Info.NetworkRange);
        foreach(GraphVertex vertex in vertices)
        {
            if(vertex is not CityStructure)
                continue;
            var structure = (CityStructure) vertex;
            ScoreNetworkStructure(structure);
        }
    }

    public void ScoreNetworkStructure(CityStructure structure)
    {
        foreach(KeyValuePair<CityStructureType, int> entry in Info.NetworkScore)
        {
            if(entry.Value == 0)
                continue;
                
            if(entry.Key == structure.Info.Type)
            {
                Events.onScoreEvent.Invoke(new Score(entry.Value, ScoreType.ADD, structure.ParentTile.gameObject));
            }
        }
    }

}
