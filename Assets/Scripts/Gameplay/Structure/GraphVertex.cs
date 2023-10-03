using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class GraphVertex
{
    
    public List<GraphEdge> Edges { get; private set; }

    public GraphVertex()
    {
        Edges = new List<GraphEdge>();
    }

    public virtual void AddNeighbor(GraphVertex neighbor, int edgeWeight = 1)
    {
        GraphEdge edge = new GraphEdge(this, neighbor, edgeWeight);
    }

    public void LinkEdge(GraphEdge edge)
    {
        if(!Edges.Contains(edge))
        {
            Edges.Add(edge);
        }
    }

}
