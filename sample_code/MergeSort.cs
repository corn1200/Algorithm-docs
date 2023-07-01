using System;
using System.Collections;

public static class MergeSort
{
  // 정렬할 배열
  private static int[] Array { get; set; }

  // 정렬 메서드
  public static void Sort(int[] arr)
  {
    // 정렬할 배열 초기화
    Array = arr;
    // 첫 번째 분할 실행
    Divide(0, arr.Length - 1);
  }

  // 분할 메서드
  private static void Divide(int left, int right)
  {
    // 왼쪽 인덱스가 오른쪽 인덱스 보다 작을 경우 실행
    if (left < right)
    {
      // 왼쪽, 오른쪽의 중간 인덱스를 구함
      int middle = (left + right) / 2;

      // 왼쪽부터 중앙까지, 중앙부터 오른쪽 인덱스까지 분할
      Divide(left, middle);
      Divide(middle + 1, right);

      // 현재 분할된 범위로 병합 실행
      Merge(left, middle, right);
    }
  }

  // 병합 메서드
  private static void Merge(int left, int middle, int right)
  {
    // 왼쪽부터 중앙까지 배열의 크기
    int n1 = middle - left + 1;
    // 중앙부터 오른쪽까지 배열의 크기
    int n2 = right - middle;

    // 분할된 왼쪽, 오른쪽 배열 선언
    int[] L = new int[n1];
    int[] R = new int[n2];

    // 왼쪽 배열 복사
    for (int i = 0; i < n1; i++)
    {
      L[i] = Array[left + i];
    }
    // 오른쪽 배열 복사
    for (int j = 0; j < n2; j++)
    {
      R[j] = Array[middle + 1 + j];
    }

    // 왼쪽, 오른쪽 배열 배치 횟수
    int x = 0, y = 0;
    // 시작 인덱스
    int k = left;

    // 왼쪽, 오른쪽 배열 중 하나가 전부 배치할 때까지 반복
    while (x < n1 && y < n2)
    {
      // 다음에 배치할 왼쪽 요소가 오른쪽 요소보다 작거나 같을 경우 실행
      if (L[x] <= R[y])
      {
        // 시작 인덱스에 왼쪽 요소 저장
        Array[k] = L[x];
        // 왼쪽 인덱스 증가
        x++;
      }
      else
      {
        // 시작 인덱스에 오른쪽 요소 저장
        Array[k] = R[y];
        // 오른쪽 인덱스 증가
        y++;
      }
      // 시작 인덱스 증가
      k++;
    }

    // 왼쪽 배열 요소 전부 배치할 때까지 반복
    while (x < n1)
    {
      // 시작 인덱스에 왼쪽 요소 저장
      Array[k] = L[x];
      // 왼쪽 인덱스, 시작 인덱스 증가
      x++;
      k++;
    }

    // 오른쪽 배열 요소 전부 배치할 때까지 반복
    while (y < n2)
    {
      // 시작 인덱스에 오른쪽 요소 저장
      Array[k] = R[y];
      // 오른쪽 인덱스, 시작 인덱스 증가
      y++;
      k++;
    }
  }
}