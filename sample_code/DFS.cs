using System;
using System.Collections;

// DFS 클래스
public static class DFS<T>
{
  // 방문한 노드 리스트
  private static List<Node<T>> Visited { get; set; }

  // DFS 탐색 메서드
  public static void Search(Node<T> start)
  {
    // 방문한 노드 리스트 초기화
    Visited = new List<Node<T>>();

    // 노드 방문 실행
    VisitNode(start);
  }

  // 노드 방문 메서드
  private static void VisitNode(Node<T> node)
  {
    // 방문한 노드를 리스트에 추가
    Visited.Add(node);

    // 방문한 노드 출력
    Console.Write(node.Data + " ");

    // 방문한 노드의 이웃 노드들에 순차 접근
    foreach (Node<T> item in node.Neighbors)
    {
      // 방문한 적 없는 노드일 경우 실행
      if (!Visited.Contains(item))
      {
        // 해당 노드 방문 실행
        VisitNode(item);
      }
    }
  }
}