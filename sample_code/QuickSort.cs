using System;
using System.Collections;

public static class QuickSort
{
  private static int[] Array { get; set; }

  public static void Sort(int[] array)
  {
    Array = array;
    Sort(0, array.Length - 1);
  }

  private static void Sort(int left, int right)
  {
    if (left < right)
    {
      int pivotIndex = Partition(left, right);

      Sort(left, pivotIndex - 1);
      Sort(pivotIndex + 1, right);
    }
  }

  private static int Partition(int left, int right)
  {
    int pivot = Array[right];
    int i = left - 1;

    for (int j = left; j < right; j++)
    {
      if (Array[j] < pivot)
      {
        i++;
        Swap(i, j);
      }
    }

    Swap(i + 1, right);
    return i + 1;
  }

  private static void Swap(int i, int j)
  {
    int temp = Array[i];
    Array[i] = Array[j];
    Array[j] = temp;
  }
}