using System;
using System.Collections;

public static class HeapSort
{
  public static void Sort(int[] arr)
  {
    Heap<int> heap = new Heap<int>();

    foreach (int i in arr)
    {
      heap.Add(i);
    }

    for (int i = arr.Length - 1; i >= 0; i--)
    {
      arr[i] = heap.Remove();
    }
  }

  // 최대 힙 클래스
  public class Heap<T>
  {
    // 트리 데이터를 저장할 리스트, 비교자
    private List<T> Tree { get; set; }
    private Comparer<T> Comparer { get; set; }

    // 기본 생성자
    public Heap()
    {
      Tree = new List<T>();
      Comparer = Comparer<T>.Default;
    }

    // Enumerator 구현
    public IEnumerator GetEnumerator()
    {
      for (int i = 1; i < Tree.Count; i++)
      {
        yield return Tree[i];
      }
    }

    // 노드 교환
    private void Swap(int a, int b)
    {
      T temp = Tree[a];
      Tree[a] = Tree[b];
      Tree[b] = temp;
    }

    // 노드 삽입
    public void Add(T data)
    {
      // 힙에 데이터 없을 경우 실행
      if (Tree.Count == 0)
      {
        // 1번 인덱스를 루트로 사용, 데이터 삽입
        Tree.Add(default);
        Tree.Add(data);
      }
      else
      {
        // 가장 끝에 노드를 삽입
        Tree.Add(data);

        // 현재 노드 위치와 부모 노드와 비교 결과
        int currIndex = Tree.Count - 1;
        int compareResult;

        // 더 이상 탐색할 수 없을 때까지 반복
        while (currIndex > 1)
        {
          // 부모 노드 위치와 부모 노드, 현재 노드 값 비교 결과
          int parentIndex = currIndex / 2;
          compareResult = Comparer.Compare(data, Tree[parentIndex]);

          // 현재 노드가 부모 노드보다 값이 클 경우 실행
          if (compareResult > 0)
          {
            // 두 노드 위치 교환
            Swap(currIndex, parentIndex);
            // 현재 노드 위치를 부모 노드 위치로 이동
            currIndex = parentIndex;
          }
          else
          {
            // 더 이상 부모 중 현재 노드보다 큰 값이 없을 경우 종료
            break;
          }
        }
      }
    }

    // 노드 제거
    public T Remove()
    {
      // 힙에 데이터 없을 경우 실행
      if (Tree.Count == 0)
      {
        // 힙에 데이터가 없다고 출력
        Console.WriteLine("힙이 비어있음.");
        return default;
      }
      else
      {
        // 루트 노드 저장
        T rootData = Tree[1];

        // 마지막 노드를 루트 자리로 이동
        // 마지막 노드 인덱스 변경
        int maxIndex = Tree.Count - 1;
        Tree[1] = Tree[maxIndex];
        Tree.RemoveAt(maxIndex);
        maxIndex = Tree.Count - 1;

        // 현재 노드 위치와 왼쪽, 오른쪽 자식과 비교 결과
        int currIndex = 1;
        int leftComparerResult;
        int rightComparerResult;

        // 더 이상 탐색할 수 없을 때까지 반복
        while (currIndex < maxIndex)
        {
          // 왼쪽, 오른쪽 자식 위치와 왼쪽, 오른쪽 자식과 비교 결과
          int leftIndex = currIndex * 2;
          int rightIndex = currIndex * 2 + 1;
          // 자식 위치가 유효할 경우에만 비교
          leftComparerResult = leftIndex <= maxIndex ? Comparer.Compare(Tree[currIndex],
              Tree[leftIndex]) : 1;
          rightComparerResult = rightIndex <= maxIndex ? Comparer.Compare(Tree[currIndex],
              Tree[rightIndex]) : 1;

          // 현재 노드가 두 자식보다 값이 작을 경우 실행
          if (leftComparerResult < 0 && rightComparerResult < 0)
          {
            // 왼쪽, 오른쪽 자식 크기 비교 후 큰 쪽 선택
            int childIndex = Comparer.Compare(Tree[leftIndex],
            Tree[rightIndex]) > 0 ? leftIndex : rightIndex;
            // 두 노드 위치 교환
            Swap(currIndex, childIndex);
            // 현재 노드 위치를 큰 쪽 자식 위치로 이동
            currIndex = childIndex;
          }
          // 현재 노드가 왼쪽보다 값이 작을 경우 실행
          else if (leftComparerResult < 0)
          {
            // 두 노드 위치 교환
            Swap(currIndex, leftIndex);
            // 현재 노드 위치를 왼쪽 자식 위치로 이동
            currIndex = leftIndex;
          }
          // 현재 노드가 오른쪽보다 값이 작을 경우 실행
          else if (rightComparerResult < 0)
          {
            // 두 노드 위치 교환
            Swap(currIndex, rightIndex);
            // 현재 노드 위치를 오른쪽 자식 위치로 이동
            currIndex = rightIndex;
          }
          else
          {
            // 더 이상 자식 중 현재 노드보다 작은 값이 없을 경우 종료
            break;
          }
        }

        // 제거한 루트 노드 반환
        return rootData;
      }
    }
  }
}