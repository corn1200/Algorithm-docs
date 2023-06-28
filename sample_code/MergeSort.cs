using System;
using System.Collections;

public static class MergeSort
{
  private static int[] Array { get; set; }

  private static void Merge(int left, int middle, int right)
  {
    int n1 = middle - left + 1;
    int n2 = right - middle;

    int[] L = new int[n1];
    int[] R = new int[n2];

    for (int i = 0; i < n1; i++)
    {
      L[i] = Array[left + i];
    }
    for (int j = 0; j < n2; j++)
    {
      R[j] = Array[middle + 1 + j];
    }

    int x = 0, y = 0;
    int k = left;
    while (x < n1 && y < n2)
    {
      if (L[x] <= R[y])
      {
        Array[k] = L[x];
        x++;
      }
      else
      {
        Array[k] = R[y];
        y++;
      }
      k++;
    }

    while (x < n1)
    {
      Array[k] = L[x];
      x++;
      k++;
    }

    while (y < n2)
    {
      Array[k] = R[y];
      y++;
      k++;
    }
  }

  private static void SortRecursive(int left, int right)
  {
    if (left < right)
    {
      int middle = (left + right) / 2;

      SortRecursive(left, middle);
      SortRecursive(middle + 1, right);

      Merge(left, middle, right);
    }
  }

  public static void Sort(int[] arr)
  {
    Array = arr;
    SortRecursive(0, arr.Length - 1);
  }
}