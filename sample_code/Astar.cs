using System;
using System.Collections;

public class Node
{
  public int X { get; set; }
  public int Y { get; set; }
  public int Cost { get; set; }
  public int TotalCost { get; set; }
  public Node Parent { get; set; }

  public Node(int x, int y, int cost, int totalCost, Node parent)
  {
    X = x;
    Y = y;
    Cost = cost;
    TotalCost = totalCost;
    Parent = parent;
  }
}

public class AStar
{
  private int[,] grid;
  private int width;
  private int height;

  public AStar(int[,] grid)
  {
    this.grid = grid;
    width = grid.GetLength(0);
    height = grid.GetLength(1);
  }

  private int ManhattanDistance(int x1, int y1, int x2, int y2)
  {
    return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
  }

  public List<Node> FindPath(int startX, int startY, int targetX, int targetY)
  {
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();

    Node startNode = new Node(startX, startY, 0, ManhattanDistance(startX, startY, targetX, startY), null);
    openList.Add(startNode);

    while (openList.Count > 0)
    {
      Node currentNode = openList[0];
      int currentIndex = 0;

      for (int i = 1; i < openList.Count; i++)
      {
        if (openList[i].TotalCost < currentNode.TotalCost)
        {
          currentNode = openList[i];
          currentIndex = i;
        }
      }

      openList.RemoveAt(currentIndex);
      closedList.Add(currentNode);

      if (currentNode.X == targetX && currentNode.Y == targetY)
      {
        List<Node> path = new List<Node>();
        while (currentNode != null)
        {
          path.Add(currentNode);
          currentNode = currentNode.Parent;
        }
        path.Reverse();
        return path;
      }

      List<Node> neighbors = new List<Node>();

      int[] dx = { -1, 1, 0, 0, };
      int[] dy = { 0, 0, -1, 1 };

      for (int i = 0; i < 4; i++)
      {
        int nx = currentNode.X + dx[i];
        int ny = currentNode.Y + dy[i];

        if (nx >= 0 && nx < width && ny >= 0 && ny < height && grid[nx, ny] == 0 && !ContainsNode(closedList, nx, ny))
        {
          int newCost = currentNode.Cost + 1;
          int heuristic = ManhattanDistance(nx, ny, targetX, targetY);
          int totalCost = newCost + heuristic;

          Node neighborNode = new Node(nx, ny, newCost, totalCost, currentNode);
          neighbors.Add(neighborNode);
        }
      }

      foreach (Node neighbor in neighbors)
      {
        if (ContainsNode(openList, neighbor.X, neighbor.Y))
        {
          Node existingNode = openList.Find(n => n.X == neighbor.X && n.Y == neighbor.Y);
          if (neighbor.Cost < existingNode.Cost)
          {
            existingNode.Cost = neighbor.Cost;
            existingNode.TotalCost = neighbor.TotalCost;
            existingNode.Parent = neighbor.Parent;
          }
        }
        else
        {
          openList.Add(neighbor);
        }
      }
    }

    return null;
  }

  private bool ContainsNode(List<Node> nodeList, int x, int y)
  {
    return nodeList.Exists(n => n.X == x && n.Y == y);
  }
}