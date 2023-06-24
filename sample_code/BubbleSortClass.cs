using System;
using System.Collections;

public class BubbleSortClass
{
  public static void BubbleSort(int[] arr)
  {
    int i, j, temp;
    int len = arr.Length;
    for (i = 0; i < len - 1; i++)
    {
      for (j = 0; j < len - i - 1; j++)
      {
        if (arr[j] > arr[j + 1])
        {
          temp = arr[j];
          arr[j] = arr[j + 1];
          arr[j + 1] = temp;
        }
      }
    }
  }
}