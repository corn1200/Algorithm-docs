using System;
using System.Collections;

// BFS 클래스
public static class BFS<T>
{
  // BFS 탐색 메서드
  public static void Search(Node<T> start)
  {
    // 방문할 노드를 저장하는 큐
    Queue<Node<T>> queue = new Queue<Node<T>>();
    // 시작 노드 삽입
    queue.Enqueue(start);

    // 방문할 노드가 있을 경우 실행
    while (queue.Count > 0)
    {
      // 큐에서 데이터 제거 및 저장
      Node<T> current = queue.Dequeue();
      // 방문한 노드 출력
      Console.Write(current.Data + " ");

      // 방문한 노드의 이웃 노드들 순회
      foreach (Node<T> item in current.Neighbors)
      {
        // 이웃 노드를 큐에 삽입
        queue.Enqueue(item);
      }
    }
  }
}