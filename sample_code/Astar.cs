using System;
using System.Collections;

// 노드 클래스
public class Node
{
  // 노드의 X, Y 좌표
  public int X { get; set; }
  public int Y { get; set; }
  // 시작 지점에서 현재 좌표까지의 이동 비용
  public int Cost { get; set; }
  // 시작 지점에서 도착 지점까지의 이동 예상 비용
  public int TotalCost { get; set; }
  // 부모 노드
  public Node Parent { get; set; }

  // 생성자
  public Node(int x, int y, int cost, int totalCost, Node parent)
  {
    X = x;
    Y = y;
    Cost = cost;
    TotalCost = totalCost;
    Parent = parent;
  }
}

// A* 클래스
public class AStar
{
  // 탐색할 2차원 공간
  private int[,] grid;
  // 공간의 넓이, 높이
  private int width;
  private int height;

  // 생성자
  public AStar(int[,] grid)
  {
    this.grid = grid;
    width = grid.GetLength(0);
    height = grid.GetLength(1);
  }

  // 휴리스틱 함수
  private int ManhattanDistance(int x1, int y1, int x2, int y2)
  {
    // 각 x 좌표와 y 좌표 거리의 절대값을 반환
    return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
  }

  // 경로 탐색 메서드
  public List<Node> FindPath(int startX, int startY, int targetX, int targetY)
  {
    // 방문할 노드 리스트, 이미 방문한 노드 리스트
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();

    // 시작 노드 선언
    Node startNode = new Node(startX, startY, 0,
        ManhattanDistance(startX, startY, targetX, targetY), null);

    // 시작 노드를 방문할 노드에 추가
    openList.Add(startNode);

    // 방문할 노드가 없을 때까지 반복
    while (openList.Count > 0)
    {
      // 방문할 노드 중 첫 번째 요소를 현재 노드로 설정
      Node currentNode = openList[0];
      // 현재 인덱스 0으로 초기화
      int currentIndex = 0;

      // 방문할 노드 리스트를 두 번째 요소부터 순회
      for (int i = 1; i < openList.Count; i++)
      {
        // i 번째 노드가 현재 노드보다 도착지까지의 예상 비용이 작을 경우 실행
        if (openList[i].TotalCost < currentNode.TotalCost)
        {
          // i 번째 노드를 현재 노드로 지정
          currentNode = openList[i];
          // 현재 인덱스를 i로 초기화
          currentIndex = i;
        }
      }

      // 방문할 노드에서 현재 노드 제거, 이미 방문한 노드에 현재 노드 추가
      openList.RemoveAt(currentIndex);
      closedList.Add(currentNode);

      // 현재 노드가 도착 지점일 경우 실행
      if (currentNode.X == targetX && currentNode.Y == targetY)
      {
        // 경로를 찾았으므로 역추적하여 반환
        List<Node> path = new List<Node>();
        // 역추적할 노드가 없을 때까지 반복
        while (currentNode != null)
        {
          // 현재 노드를 경로에 추가
          path.Add(currentNode);
          // 부모 노드를 현재 노드로 지정
          currentNode = currentNode.Parent;
        }
        // 역추적한 경로를 반전
        path.Reverse();

        // 경로 반환
        return path;
      }

      // 이웃 노드 리스트를 선언
      List<Node> neighbors = new List<Node>();
      // 현재 노드의 상하좌우 이웃 노드를 확인
      int[] dx = { -1, 1, 0, 0, };
      int[] dy = { 0, 0, -1, 1 };

      for (int i = 0; i < 4; i++)
      {
        // 현재 노드 좌표에 상하좌우 좌표를 구함
        int nx = currentNode.X + dx[i];
        int ny = currentNode.Y + dy[i];

        // 이웃 노드가 범위 내에 있고 벽이 아니며
        // 아직 방문하지 않은 노드인 경우 실행
        if (nx >= 0 && nx < width && ny >= 0 && ny < height
            && grid[nx, ny] == 0 && !ContainsNode(closedList, nx, ny))
        {
          // 노드 비용은 이동 거리에 따라 증가
          int newCost = currentNode.Cost + 1;
          // 상하좌우 좌표에서 도착 지점까지의 예상 비용을 구함
          int heuristic = ManhattanDistance(nx, ny, targetX, targetY);
          // 시작 지점에서 상하좌우 좌표까지의 이동 비용
          // + 상하좌우 좌표에서 도착 지점까지의 예상 비용
          int totalCost = newCost + heuristic;

          // 새로운 이웃 노드 객체 생성 후 이웃 노드 리스트에 추가
          Node neighborNode = new Node(nx, ny, newCost, totalCost, currentNode);
          neighbors.Add(neighborNode);
        }
      }

      // 이웃 노드 순회
      foreach (Node neighbor in neighbors)
      {
        // 이웃 좌표에 해당하는 노드가 방문할 노드 리스트에 있을 경우 실행
        if (ContainsNode(openList, neighbor.X, neighbor.Y))
        {
          // 이미 방문할 노드 목록에 있는 경우 더 적은 비용으로 갱신
          Node existingNode = openList.Find(n => n.X == neighbor.X && n.Y == neighbor.Y);
          // 이웃 노드 이동 비용이 방문할 노드 이동 비용보다 적은 경우 실행
          if (neighbor.Cost < existingNode.Cost)
          {
            // 방문할 노드의 이동 비용, 도착지까지 예상 비용, 부모 노드를 변경
            existingNode.Cost = neighbor.Cost;
            existingNode.TotalCost = neighbor.TotalCost;
            existingNode.Parent = neighbor.Parent;
          }
        }
        else
        {
          // 방문할 노드에 이웃 노드 추가
          openList.Add(neighbor);
        }
      }
    }

    // 경로를 찾지 못한 경우
    return null;
  }

  // 해당 좌표 노드가 리스트에 있는지 확인하는 메서드
  private bool ContainsNode(List<Node> nodeList, int x, int y)
  {
    return nodeList.Exists(n => n.X == x && n.Y == y);
  }
}