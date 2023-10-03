using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public static class Graphs
{
    
    public static List<GraphVertex> GetAllWithinDistance(GraphVertex start, int dist)
    {
        var vertDistances = new Dictionary<GraphVertex, int>();
        var processQueue = new Queue<GraphVertex>();
        
        processQueue.Enqueue(start);
        while(processQueue.Count > 0)
        {
            var vertex = processQueue.Peek();
            var distRemaining = dist;
            if (vertDistances.TryGetValue(vertex, out int distance))
                distRemaining = dist - distance;
            var checkNeighbors = GetNeighborsWithinDistance(vertex, distRemaining);
            foreach(KeyValuePair<GraphVertex,int> neighbor in checkNeighbors)
            {
                if (vertDistances.ContainsKey(neighbor.Key))
                    continue;
                vertDistances.Add(neighbor.Key, neighbor.Value + distance);
                processQueue.Enqueue(neighbor.Key);
            }
            processQueue.Dequeue();
        }

        return vertDistances.Keys.ToList();
    }

    public static Dictionary<GraphVertex, int> GetNeighborsWithinDistance(GraphVertex start, int dist)
    {
        var ret = new Dictionary<GraphVertex, int>();

        foreach(GraphEdge edge in start.Edges)
        {
            if(edge.Weight <= dist)
            {
                GraphVertex vertex = edge.Vertices.Find(
                    v => !System.Object.ReferenceEquals(v, start)
                );
                ret.Add(vertex, edge.Weight);
            }
        }
        return ret;
    }

}
