using System;
using System.Collections;

public class BubbleSortClass
{
  // 버블 정렬 함수
  public static void BubbleSort(int[] arr)
  {
    // 정렬 횟수, 정렬 범위, 데이터 임시 저장 변수
    int i, j, temp;
    // n 크기 선언
    int len = arr.Length;

    // n번 반복
    for (i = 0; i < len - 1; i++)
    {
      // n번 반복할 때마다 반복 범위 줄여나감
      for (j = 0; j < len - i - 1; j++)
      {
        // 현재 원소가 다음 원소보다 클 경우 실행
        if (arr[j] > arr[j + 1])
        {
          // 현재 원소와 다음 원소 위치 변경
          temp = arr[j];
          arr[j] = arr[j + 1];
          arr[j + 1] = temp;
        }
      }
    }
  }
}