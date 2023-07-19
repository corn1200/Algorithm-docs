using System;
using System.Collections;

public static class Dijkstra<T>
{
  private class TargetNode<T> : IComparable<TargetNode<T>>
  {
    private Node<T> Target { get; set; }
    private int Cost { get; set; }

    public TargetNode(Node<T> target, int cost)
    {
      Target = target;
      Cost = cost;
    }

    public Node<T> GetTarget() { return Target; }

    public int CompareTo(TargetNode<T> other)
    {
      if (other == null)
      {
        return 1;
      }

      return Cost.CompareTo(other.Cost);
    }
  }

  private static HashSet<Node<T>> NonVisitedNode { get; set; }
  private static HashSet<Node<T>> VisitedNode { get; set; }
  private static MinHeap<TargetNode<T>> PriorityQueue { get; set; }
  private static Dictionary<T, int> Distance { get; set; }

  public static void Execute(Graph<T> graph, Node<T> start)
  {
    NonVisitedNode = new HashSet<Node<T>>(graph.GetNodeList());
    VisitedNode = new HashSet<Node<T>>();
    PriorityQueue = new MinHeap<TargetNode<T>>();
    Distance = new Dictionary<T, int>();

    foreach (var item in NonVisitedNode)
    {
      Distance.Add(item.Data, int.MaxValue);
    }
    Distance[start.Data] = 0;

    Node<T> nextVisitNode = start;
    while (NonVisitedNode.Count > 0)
    {
      if (VisitedNode.Contains(nextVisitNode))
      {
        nextVisitNode = PriorityQueue.Remove().GetTarget();
        continue;
      }
      VisitedNode.Add(nextVisitNode);
      NonVisitedNode.Remove(nextVisitNode);

      int i = 0;
      foreach (var item in nextVisitNode.Neighbors)
      {
        int newDistant = Distance[nextVisitNode.Data] + nextVisitNode.Weights[i];
        if (Distance[item.Data] > newDistant)
        {
          Distance[item.Data] = newDistant;
        }

        if (!VisitedNode.Contains(item))
        {
          PriorityQueue.Add(new TargetNode<T>(item, Distance[item.Data]));
        }
        i++;
      }
      try
      {
        nextVisitNode = PriorityQueue.Remove().GetTarget();
      }
      catch
      {
        continue;
      }
    }

    foreach (var item in Distance)
    {
      Console.WriteLine($"{item.Key}: {item.Value}");
    }
  }
}