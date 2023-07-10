using System;
using System.Collections;

public static class DFS<T>
{
  private static List<Node<T>> Visisted { get; set; }

  private static void SearchUtil(Node<T> node)
  {
    Visisted.Add(node);

    Console.Write(node.Data + " ");

    foreach (Node<T> item in node.Neighbors)
    {
      if (!Visisted.Contains(item))
      {
        SearchUtil(item);
      }
    }
  }

  public static void Search(Node<T> start)
  {
    Visisted = new List<Node<T>>();

    SearchUtil(start);
  }
}