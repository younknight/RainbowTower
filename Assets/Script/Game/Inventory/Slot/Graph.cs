using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    myGraph graph;
    struct myGraph
    {
        public int numV; // 정점의 수
        public int numE; // 간선의 수
        public List<int>[] vArray;
        public List<bool> isActive;
    }
    public Graph(int numV)
    {
        graph = new myGraph();
        graph.numV = numV;
        graph.vArray = new List<int>[numV];
        graph.isActive = new List<bool>();
        for (int i = 0; i < numV; i++)
        {
            graph.vArray[i] = new List<int>();
        }
        for (int i = 0; i < numV; i++)
        {
            graph.isActive.Add(false);
        }
        SetEdge();
    }
    void SetEdge()
    {
        AddEdge(0, 1);
        AddEdge(0, 4);

        AddEdge(1, 0);
        AddEdge(1, 2);
        AddEdge(1, 5);

        AddEdge(2, 1);
        AddEdge(2, 3);
        AddEdge(2, 6);

        AddEdge(3, 2);
        AddEdge(3, 7);

        AddEdge(4, 5);
        AddEdge(4, 0);
        AddEdge(4, 8);

        AddEdge(5, 1);
        AddEdge(5, 4);
        AddEdge(5, 6);
        AddEdge(5, 9);

        AddEdge(6, 2);
        AddEdge(6, 5);
        AddEdge(6, 7);
        AddEdge(6, 10);

        AddEdge(7, 3);
        AddEdge(7, 6);
        AddEdge(6, 11);

        AddEdge(8, 4);
        AddEdge(8, 9);
        AddEdge(8, 12);

        AddEdge(9, 8);
        AddEdge(9, 5);
        AddEdge(9, 13);
        AddEdge(9, 10);

        AddEdge(10, 6);
        AddEdge(10, 9);
        AddEdge(10, 11);
        AddEdge(10, 14);

        AddEdge(11, 7);
        AddEdge(11, 10);
        AddEdge(11, 15);

        AddEdge(12, 8);
        AddEdge(12, 13);

        AddEdge(13, 14);
        AddEdge(13, 9);
        AddEdge(13, 12);

        AddEdge(14, 10);
        AddEdge(14, 13);
        AddEdge(14, 15);

        AddEdge(15, 11);
        AddEdge(15, 14);
    }
    public void AddEdge(int fromV, int toV)
    {
        if (!graph.vArray[fromV].Contains(toV))
        {
            graph.numE++;
            graph.vArray[fromV].Add(toV);
            graph.vArray[toV].Add(fromV);
        }
    }

    public void ShowGraphEdgeInfo()
    {
        for (int i = 0; i < graph.numV; i++)
        {
            Debug.Log(i + " : ");
            foreach (var VARIABLE in graph.vArray[i])
            {
                Debug.Log(VARIABLE + ", ");
            }
        }
    }
    public void Active(int index)
    {
        graph.isActive[index] = true;
    }
    public int BFS(int start)
    {
        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[graph.numV];
        int count = 0;
        q.Enqueue(start);
        visited[start] = true;

        while (q.Count > 0)
        {
            int now = q.Dequeue();
            foreach (int next in graph.vArray[now])
            {
                // 이미 방문했는가?
                if (!graph.isActive[next])
                    continue;
                if (visited[next])
                    continue;
                q.Enqueue(next);
                count++;
                visited[next] = true;
            }
        }
        Debug.Log(count);
        return count;
    }
}
