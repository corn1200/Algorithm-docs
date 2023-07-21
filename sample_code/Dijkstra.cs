using System;
using System.Collections;

// 다익스트라 클래스
public static class Dijkstra<T>
{
  // 목표 노드 클래스
  private class TargetNode<T> : IComparable<TargetNode<T>>
  {
    // 목표 노드와 이동에 드는 비용
    private Node<T> Target { get; set; }
    private int Cost { get; set; }

    // 생성자
    public TargetNode(Node<T> target, int cost)
    {
      // 목표 노드와 이동 비용 초기화
      Target = target;
      Cost = cost;
    }

    // 목표 노드 반환
    public Node<T> GetTarget() { return Target; }

    // 목표 노드끼리의 비교 연산 구현
    public int CompareTo(TargetNode<T> other)
    {
      // 비교 대상이 null일 경우 비교 주체가 더 큰 걸로 판단
      if (other == null)
      {
        return 1;
      }

      // 이동 비용 비교로 목표 노드 크기 비교
      return Cost.CompareTo(other.Cost);
    }
  }

  // 아직 방문하지 않은 노드 집합과 방문한 노드 집합
  private static HashSet<Node<T>> NonVisitedNode { get; set; }
  private static HashSet<Node<T>> VisitedNode { get; set; }
  // 다음 번 방문 노드를 저장하는 우선순위 큐, 노드의 거리를 저장하는 딕셔너리
  private static MinHeap<TargetNode<T>> PriorityQueue { get; set; }
  private static Dictionary<T, int> Distance { get; set; }

  // 다익스트라 알고리즘 실행 메서드
  public static void Execute(Graph<T> graph, Node<T> start)
  {
    // 멤버변수 초기화
    NonVisitedNode = new HashSet<Node<T>>(graph.GetNodeList());
    VisitedNode = new HashSet<Node<T>>();
    PriorityQueue = new MinHeap<TargetNode<T>>();
    Distance = new Dictionary<T, int>();

    // 모든 노드 거리를 정수 최대값으로 설정
    foreach (var item in NonVisitedNode)
    {
      Distance.Add(item.Data, int.MaxValue);
    }
    // 시작 노드의 거리를 0으로 설정
    Distance[start.Data] = 0;

    // 다음 방문할 노드를 시작 노드로 설정
    Node<T> nextVisitNode = start;
    // 모든 노드를 방문할 때까지 반복
    while (NonVisitedNode.Count > 0)
    {
      // 이번에 방문할 노드가 이미 방문한 노드인 경우 실행
      if (VisitedNode.Contains(nextVisitNode))
      {
        // 다음 방문할 노드를 우선순위 큐에서 꺼내어 변경 후 반복문 넘어감
        nextVisitNode = PriorityQueue.Remove().GetTarget();
        continue;
      }
      // 방문한 노드 집합에 다음 방문할 노드를 추가
      VisitedNode.Add(nextVisitNode);
      // 방문하지 않은 노드 집합에서 다음 방문할 노드를 제거
      NonVisitedNode.Remove(nextVisitNode);

      // 인접 노드의 인덱스
      int i = 0;
      // 인접 노드를 전부 순회
      foreach (var item in nextVisitNode.Neighbors)
      {
        // 방문한 노드의 거리와 인접 노드의 거리를 합하여 새로운 거리 값 생성
        int newDistant = Distance[nextVisitNode.Data] + nextVisitNode.Weights[i];
        // 새로운 거리 값이 기존 인접 노드의 거리 값 보다 작을 경우 실행
        if (Distance[item.Data] > newDistant)
        {
          // 인접 노드의 거리 값 업데이트
          Distance[item.Data] = newDistant;
        }

        // 인접 노드가 아직 방문한 적 없는 노드일 경우 실행
        if (!VisitedNode.Contains(item))
        {
          // 우선순위 큐에 다음 방문할 목표 노드로 추가
          PriorityQueue.Add(new TargetNode<T>(item, Distance[item.Data]));
        }
        // 인접 노드 인덱스 증가
        i++;
      }

      try
      {
        // 다음 방문할 노드를 우선순위 큐에서 꺼내어 변경
        nextVisitNode = PriorityQueue.Remove().GetTarget();
      }
      catch
      {
        continue;
      }
    }

    // 계산된 시작 노드부터 각 노드까지의 최단 거리 표출
    foreach (var item in Distance)
    {
      Console.WriteLine($"{item.Key}: {item.Value}");
    }
  }
}