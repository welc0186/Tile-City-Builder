using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphEdge
{
    
    public int Weight { get; private set; }
    public List<GraphVertex> Vertices { get; private set; }

    public GraphEdge(GraphVertex vertex1, GraphVertex vertex2, int weight)
    {
        Weight = weight;
        Vertices = new List<GraphVertex> {vertex1, vertex2};
        vertex1.LinkEdge(this);
        vertex2.LinkEdge(this);
    }

}
