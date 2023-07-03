using System;
using System.Collections;

// 퀵 정렬 클래스
public static class QuickSort
{
  // 정렬할 배열
  private static int[] Array { get; set; }

  // 호출용 정렬 메서드
  public static void Sort(int[] array)
  {
    // 배열 초기화
    Array = array;

    // 정렬 메서드 실행
    Sort(0, array.Length - 1);
  }

  // 내부 동작용 정렬 메서드
  private static void Sort(int left, int right)
  {
    // 왼쪽, 오른쪽 범위가 유효한 경우에 실행
    if (left < right)
    {
      // 왼쪽, 오른쪽 범위를 기준으로 피벗이 이동한 위치 선언
      int pivotIndex = Partition(left, right);

      // 왼쪽부터 현재 피벗 전까지, 피벗 뒤부터 오른쪽까지 정렬
      Sort(left, pivotIndex - 1);
      Sort(pivotIndex + 1, right);
    }
  }

  // 파티션 분할 메서드
  private static int Partition(int left, int right)
  {
    // 맨 오른쪽 요소를 피벗 값으로 선정
    int pivot = Array[right];
    // 피벗 값 미만 인덱스
    int i = left - 1;

    // 왼쪽부터 오른쪽 범위까지 반복
    for (int j = left; j < right; j++)
    {
      // 현재 요소 값이 피벗 값보다 작을 경우 실행
      if (Array[j] < pivot)
      {
        // 피벗 값 보다 큰 값과 작은 값을 교환
        i++;
        Swap(i, j);
      }
    }

    // 피벗 값보다 작은 모든 값 뒤의 요소와 피벗 요소를 교환한다
    Swap(i + 1, right);
    // 피벗이 이동한 위치 반환
    return i + 1;
  }

  // 배열 요소 교환 메서드
  private static void Swap(int i, int j)
  {
    // i 요소와 j 요소 위치 교환
    int temp = Array[i];
    Array[i] = Array[j];
    Array[j] = temp;
  }
}