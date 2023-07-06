using System;
using System.Collections;

//트리 정렬 클래스
public static class TreeSort
{
  // 정렬할 배열, 배열 인덱스
  private static int[] Array { get; set; }
  private static int Index { get; set; }

  // 정렬 메서드
  public static void Sort(int[] arr)
  {
    // 이진 탐색 트리 선언
    BinarySearchTree tree = new BinarySearchTree();

    // 배열, 인덱스 초기화
    Array = arr;
    Index = 0;

    // 모든 배열 요소를 이진 탐색 트리에 삽입
    foreach (int item in Array)
    {
      tree.Add(item);
    }

    // 중위 순회 방식으로 배열에 요소 저장
    tree.InOrderTraversal();
  }

  // 노드 클래스
  private class Node
  {
    // 노드 데이터, 왼쪽 노드, 오른쪽 노드
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    // 생성자
    public Node(int data)
    {
      Data = data;
    }
  }

  // 이진 탐색 트리 클래스
  private class BinarySearchTree
  {
    // 루트 노드, 노드 비교자
    public Node Root { get; set; }
    private Comparer<int> Comparer { get; set; }

    // 기본 생성자
    public BinarySearchTree()
    {
      Comparer = Comparer<int>.Default;
    }

    // 노드 추가
    public void Add(int data)
    {
      // 현재 노드
      Node current = Root;

      // 현재 노드가 없을 경우 실행
      if (current == null)
      {
        // 새로운 노드를 루트 노드로 지정
        Root = new Node(data);
      }
      else
      {
        // 탐색할 수 없을 때까지 반복
        while (current != null)
        {
          // 비교자를 통해 현재 노드 값과 입력 값을 비교
          int compareResult = Comparer.Compare(current.Data, data);

          // 현재 노드 값과 입력 값이 동일할 경우 실행
          if (compareResult == 0)
          {
            Console.WriteLine("중복된 값 존재");
            return;
          }
          // 입력 값이 현재 노드 값 보다 작을 경우 실행
          else if (compareResult > 0)
          {
            // 현재 노드의 왼쪽이 비어 있을 경우 실행
            if (current.Left == null)
            {
              // 현재 노드의 왼쪽에 새로운 노드 추가
              current.Left = new Node(data);
              return;
            }
            // 왼쪽 노드로 이동
            current = current.Left;
          }
          // 입력 값이 현재 노드 값 보다 클 경우 실행
          else if (compareResult < 0)
          {
            // 현재 노드의 오른쪽이 비어 있을 경우 실행
            if (current.Right == null)
            {
              // 현재 노드의 오른쪽에 새로운 노드 추가
              current.Right = new Node(data);
              return;
            }
            // 오른쪽 노드로 이동
            current = current.Right;
          }
        }
      }
    }

    // 노드 제거
    public void Remove(int data)
    {
      // 현재 노드
      Node current = Root;

      // 삭제할 노드가 루트인 경우 실행
      if (Comparer.Compare(current.Data, data) == 0)
      {
        // 루트 노드 제거
        Root = null;
      }

      // 탐색할 수 없을 때까지 반복
      while (current != null)
      {
        // 비교자를 통해 현재 노드 값과 입력 값을 비교
        int compareResult = Comparer.Compare(current.Data, data);

        // 입력 값이 현재 노드 보다 작을 경우 실행
        if (compareResult > 0)
        {
          // 왼쪽 노드가 없을 경우 실행
          if (current.Left == null)
          {
            return;
          }

          // 비교자를 통해 왼쪽 노드 값과 입력 값을 비교
          compareResult = Comparer.Compare(current.Left.Data, data);
          // 왼쪽 노드 값과 입력 값이 동일할 경우 실행
          if (compareResult == 0)
          {
            // 왼쪽 노드 제거
            current.Left = null;
            return;
          }
          // 왼쪽 노드로 이동
          current = current.Left;
        }
        // 입력 값이 현재 노드 보다 클 경우 실행
        else if (compareResult < 0)
        {
          // 오른쪽 노드가 없을 경우 실행
          if (current.Right == null)
          {
            return;
          }

          // 비교자를 통해 왼쪽 노드 값과 입력 값을 비교
          compareResult = Comparer.Compare(current.Right.Data, data);
          // 오른쪽 노드 값과 입력 값이 동일할 경우 실행
          if (compareResult == 0)
          {
            // 오른쪽 노드 제거
            current.Right = null;
            return;
          }
          // 오른쪽 노드로 이동
          current = current.Right;
        }
      }
    }

    // 노드 검색
    public Node Get(int data)
    {
      // 현재 노드
      Node current = Root;

      // 탐색할 수 없을 때까지 반복
      while (current != null)
      {
        // 비교자를 통해 현재 노드 값과 입력 값을 비교
        int compareResult = Comparer.Compare(current.Data, data);

        // 현재 노드 값과 입력 값이 동일할 경우 실행
        if (compareResult == 0)
        {
          // 현재 노드 반환
          return current;
        }
        // 입력 값이 현재 노드 보다 작을 경우 실행
        else if (compareResult > 0)
        {
          // 왼쪽 노드로 이동
          current = current.Left;
        }
        // 입력 값이 현재 노드 보다 클 경우 실행
        else if (compareResult < 0)
        {
          // 오른쪽 노드로 이동
          current = current.Right;
        }
      }

      return null;
    }

    // 노드 존재하는지 확인
    public bool Contains(int data)
    {
      // 노드 검색 후 null이 아니라면 true 반환
      Node getNode = Get(data);
      return getNode != null;
    }

    // 중위 순회(In-order)
    public void InOrderTraversal()
    {
      // 노드 이동 경로를 저장할 스택
      // 방문 완료한 노드를 저장할 HashSet
      Stack<Node> stack = new Stack<Node>();
      HashSet<Node> visited = new HashSet<Node>();

      // 이동 경로에 루트 노드 추가
      stack.Push(Root);

      // 모든 노드를 순회할 때까지 반복
      while (stack.Count > 0)
      {
        // 현재 위치 노드, 현재 노드의 왼쪽 노드
        Node current = stack.Peek();
        Node left = current.Left;

        // 왼쪽 노드가 없거나 이미 방문한 노드일 때 까지 반복
        while (left != null && !visited.Contains(left))
        {
          // 이동 경로에 왼쪽 노드 추가
          stack.Push(left);
          // 왼쪽 노드를 이동한 노드의 왼쪽 노드로 교체
          left = left.Left;
        }

        // 이동 경로 중 가장 최근 노드를 방문
        Node visit = stack.Pop();

        // 배열에 저장 후 인덱스 증가
        Array[Index] = visit.Data;
        Index++;

        // 노드 집합에 방문한 노드 저장
        visited.Add(visit);

        // 방문한 노드에 오른쪽 노드가 있을 경우 실행
        if (visit.Right != null)
        {
          // 이동 경로에 오른쪽 노드 추가
          stack.Push(visit.Right);
        }
      }
    }
  }
}