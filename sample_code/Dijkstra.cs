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

  // 미방문 노드 집합
  private static HashSet<Node<T>> NonVisitedNode { get; set; }
  // 다음 방문할 노드를 저장하는 우선순위 큐
  private static MinHeap<TargetNode<T>> PriorityQueue { get; set; }
  // 노드의 거리를 저장하는 딕셔너리, 경로 상의 이전 노드를 저장하는 딕셔너리
  private static Dictionary<T, int> Distance { get; set; }
  private static Dictionary<T, T> BeforeNode { get; set; }

  // 다익스트라 알고리즘 실행 메서드
  public static void Execute(Graph<T> graph, Node<T> start)
  {
    // 멤버변수 초기화
    NonVisitedNode = new HashSet<Node<T>>(graph.GetNodeList());
    PriorityQueue = new MinHeap<TargetNode<T>>();
    Distance = new Dictionary<T, int>();
    BeforeNode = new Dictionary<T, T>();

    // 모든 미방문 노드를 순회
    foreach (var item in NonVisitedNode)
    {
      // 노드 거리 정수 최대값으로 설정
      Distance.Add(item.Data, int.MaxValue);
      // 이전 노드를 기본값(null)으로 설정
      BeforeNode.Add(item.Data, default);
    }
    // 시작 노드의 거리를 0으로 설정
    Distance[start.Data] = 0;

    // 다음 방문할 노드를 시작 노드로 설정
    Node<T> nextVisitNode = start;
    // 모든 노드를 방문할 때까지 반복
    while (NonVisitedNode.Count > 0)
    {
      // 이번에 방문할 노드가 이미 방문한 노드인 경우 실행
      if (!NonVisitedNode.Contains(nextVisitNode))
      {
        // 다음 방문할 노드를 우선순위 큐에서 꺼내어 변경 후 반복문 넘어감
        nextVisitNode = PriorityQueue.Remove().GetTarget();
        continue;
      }
      // 미방문 노드 집합에서 다음 방문할 노드를 제거
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
          // 인접 노드의 이전 노드 업데이트
          BeforeNode[item.Data] = nextVisitNode.Data;
        }

        // 인접 노드가 미방문 노드일 경우 실행
        if (NonVisitedNode.Contains(item))
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

    // 노드 별 경로 저장
    Dictionary<T, string> pathMemo = new Dictionary<T, string>();
    // 시작 노드부터 각 노드까지의 최단 거리와 경로 표출
    foreach (var item in Distance)
    {
      Console.WriteLine($"{item.Key} -> Distance: {item.Value}, " +
          $"Path: {NodePath(pathMemo, item.Key)}");
    }
  }

  // 목표 노드까지의 경로 표출 메서드
  private static string NodePath(Dictionary<T, string> pathMemo, T thisNode)
  {
    // 경로 저장 스택, 방문 노드 집합
    Stack<T> path = new Stack<T>();
    HashSet<T> visited = new HashSet<T>();

    // 결과 문자열
    string result = "";

    // 경로 상의 이전 노드
    T beforeNode = thisNode;

    // 이전 노드가 없을 때까지 반복
    while (beforeNode != null)
    {
      // 이전 노드의 경로가 이미 있을 경우 결과값에 경로 저장하고 반복 종료
      // 혹은 이전 노드가 이미 방문한 적 있다면 반복 종료
      if (pathMemo.TryGetValue(beforeNode, out result) ||
          visited.Contains(beforeNode))
      {
        break;
      }
      // 경로에 이전 노드 저장, 방문 노드 집합에 이전 노드 저장
      path.Push(beforeNode);
      visited.Add(beforeNode);
      // 이전 노드를 이전 노드의 이전 노드로 변경
      beforeNode = BeforeNode[beforeNode];
    }

    // 스택에 저장한 경로를 결과값에 저장
    foreach (var item in path)
    {
      result += $"{item} ";
    }

    // 해당 노드의 최단 경로 저장
    pathMemo[thisNode] = result;

    // 결과값 반환
    return result;
  }
}