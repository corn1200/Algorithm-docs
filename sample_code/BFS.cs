using System;
using System.Collections;

public static class BFS<T>
{
  public static void Search(Node<T> start)
  {
    Queue<Node<T>> queue = new Queue<Node<T>>();
    queue.Enqueue(start);

    while (queue.Count > 0)
    {
      Node<T> current = queue.Dequeue();
      Console.Write(current.Data + " ");

      foreach (Node<T> item in current.Neighbors)
      {
        queue.Enqueue(item);
      }
    }
  }
}