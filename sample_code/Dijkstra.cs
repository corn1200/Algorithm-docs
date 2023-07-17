using System;
using System.Collections;

class Graph
{
  private int V;
  private List<Node>[] adj;

  class Node
  {
    public int Vertex;
    public int Weight;

    public Node(int vertex, int weight)
    {
      Vertex = vertex;
      Weight = weight;
    }
  }

  public Graph(int v)
  {
    V = v;
    adj = new List<Node>[V];
    for (int i = 0; i < V; i++)
    {
      adj[i] = new List<Node>();
    }
  }

  public void AddEdge(int v, int w, int weight)
  {
    adj[v].Add(new Node(w, weight));
    adj[w].Add(new Node(v, weight));
  }

  public void Dijkstra(int source)
  {
    int[] dist = new int[V];
    bool[] visited = new bool[V];
    int[] prev = new int[V];

    for (int i = 0; i < V; i++)
    {
      dist[i] = int.MaxValue;
      visited[i] = false;
      prev[i] = -1;
    }

    dist[source] = 0;

    for (int count = 0; count < V; count++)
    {
      int u = MinimumDistance(dist, visited);

      visited[u] = true;

      foreach (Node node in adj[u])
      {
        int v = node.Vertex;
        int weight = node.Weight;

        if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
        {
          dist[v] = dist[u] + weight;
          prev[v] = u;
        }
      }
    }

    Console.WriteLine("Vertex\tDistance\tPath");
    for (int i = 0; i < V; i++)
    {
      Console.Write(i + "\t" + dist[i] + "\t\t");
      PrintPath(prev, i);
      Console.WriteLine();
    }
  }

  private int MinimumDistance(int[] dist, bool[] visisted)
  {
    int min = int.MaxValue;
    int minIndex = -1;

    for (int v = 0; v < V; v++)
    {
      if (!visisted[v] && dist[v] <= min)
      {
        min = dist[v];
        minIndex = v;
      }
    }

    return minIndex;
  }

  private void PrintPath(int[] prev, int v)
  {
    if (v == -1)
    {
      return;
    }

    PrintPath(prev, prev[v]);
    Console.Write(v + " ");
  }
}