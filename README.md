# Algorithm-docs

# 목차
* [1. 정렬](#1-정렬)
  * [1.1. O(n^2)](#11-on2)
    * [1.1.1. 버블 정렬](#111-버블-정렬)
    * [1.1.2. 칵테일 정렬](#112-칵테일-정렬)
    * [1.1.3. 콤브 정렬](#113-콤브-정렬)
    * [1.1.4. 선택 정렬](#114-선택-정렬)
    * [1.1.5. 삽입 정렬](#115-삽입-정렬)
  * [1.2. O(n log n)](#12-on-log-n)
    * [1.2.1. 병합 정렬](#121-병합-정렬)

# 1. 정렬
데이터를 정렬해야 하는 이유는 탐색을 위해서이다.  
탐색할 대상 데이터가 정렬되어 있지 않다면 순차 탐색 이외에 다른 알고리즘을 사용할 수 없지만 데이터가 정렬되어 있다면 이진 탐색이라는 강력한 알고리즘을 사용할 수 있다. (알고리즘 문제 등을 풀 때 O(n log n) 보다 빠른 방법은 도저히 없을 것 같다고 판단되는 문제인 경우 일단 정렬하는 걸 가정하고 생각해봐도 무방하다.)   
삽입과 삭제가 자주 되는 자료의 경우 정렬에 더 많은 시간이 들어가므로 순차 탐색을 하는 경우도 있지만(이런 경우는 해시 탐색을 사용하기도 한다.) 대부분의 경우 삽입/삭제보다는 데이터를 조회하는 것이 압도적으로 많고 조회에 필요한 것이 바로 검색이다.

이미 정렬된 데이터의 특징은 어떤 값을 임의로 집었을 때 해당 값을 집은 위치의 오른쪽에는 무조건 그것보다 크거나 같은 값이 있고, 그 위치의 왼쪽에는 무조건 그것보다 작거나 같은 값이 있다는 것이다.   
따라서 컴퓨터가 어떤 값을 딱 집었을 때 찾고자 하는 값보다 집어올린 값이 작다면 그 위치보다 왼쪽은 볼 필요가 없이 그보다 오른쪽만 보면 된다.  
컴퓨터가 어떤 값을 집어올리는 위치가 후보군의 가운데인 탐색 알고리즘이 이진 탐색 알고리즘이다.  
이진 탐색 알고리즘은 최악의 경우라도 log n의 성능을 보이는데 예를 들어 43억 개의 정렬된 자료가 들어있는 데이터에서 어떤 값을 찾아야 할 때 최악의 비교 횟수(찾는 값이 없는 경우)는 겨우 32회에 불과하다.   
33회 비교시에는 약 86억 개의 자료를 탐색할 수 있다.   
더 발전한 알고리즘인 비례탐색 알고리즘(찾는 값이 후보군의 최소값과 최대값 사이의 몇 % 위치에 있는지 계산)은 더 적은 횟수의 비교로 원하는 값을 찾아낼 수 있다.   
컴퓨터에서 정렬을 수행하는 이유 중 가장 큰 이유가 바로 이 이진 탐색이 가능한 데이터를 만들기 위해서이다. (정렬을 필요로 하지 않는 해시 탐색이라는 O(1) 시간복잡도의 알고리즘도 있지만 탐색 항목을 따로 작성해야 한다.)

보통 컴퓨터 분야에서 연구되는 문제들의 경우 사람들이 푸는 방식을 흉내내는 경우가 많은데, 정렬 문제 역시 사람들이 푸는 방식을 흉내낸 형태이다.   
주어진 데이터들이 있으면 값들을 서로 비교하여 순서에 맞게 자리를 바꿔주는 형태로 정렬을 하는데 이를 "비교정렬"이라고 부른다.  

이론과 달리 실제로 알고리즘을 구현하고 실행해 보면 의외로 결과가 다르게 나오는 경우가 종종 있다.  
주로 하드웨어 입출력이 관여해서 그 부분에 걸리는 시간이 정렬 알고리즘마다 과하게 달라서 더 느려야 하는 알고리즘이 더 빠르다던가, 아니면 정렬된 자료들을 대상으로 퀵소트 VS 다른 정렬 알고리즘에서 자주 관찰되는 현상 중 하나로 이론상 정렬된 자료에서는 퀵소트가 더 느려야 하지만 비교하는 기준점이 하나로 고정되어서 그 기준점이 많은 비교를 행하는 퀵소트 특성상 레지스터에 비교하는 기준점 원소를 올려놓고 신속하게 메모리에서 다음 비교할 원소를(메모리에서 연속된) 예측하여 가져오는 경우, 이 과정이 다른 정렬 알고리즘의 메모리에서 레지스터로 올리는 과정에 걸리는 시간이 생략되어 오히려 더 빠른 경우를 볼 수 있다.

실제 응용에서는 상황에 따라 두 가지 이상의 정렬 방법을 사용하는 경우가 많다.  
예를 들면, 정렬 대상이 특정 크기 이하로 단편화될 때까지는 퀵정렬을 쓰다가, 그 특정 크기 이하가 됐을 때에는 작은 규모에서 강점을 보이는 삽입정렬을 쓴다거나, 혹은 특정 횟수 이상 재귀호출이 발생하면 O(n log n)이 보장되는 힙정렬을 쓴다.

# 1.1. O(n^2)
대개 계산 시간이 정렬한 자료의 수의 제곱에 비례해서 늘어난다.   
즉, 1만 개를 1초에 정렬하면 10만 개를 정렬하는 데에는 100초 정도가 필요하다.

# 1.1.1. 버블 정렬
![버블 정렬](/img/bubble_sort0.gif)

버블 정렬의 실행 과정을 표현한 그림.

1번째와 2번째 원소를 비교하여 정렬하고, 2번째와 3번째, ..., n-1번째와 n번째를 정렬한 뒤 다시 처음으로 돌아가 이번에는 n-2번째와 n-1번째까지, ...해서 최대 n(n - 1) / 2 번 정렬한다. (이것은 최악의 경우이다. 최선의 경우(이미 정렬된 경우)는 0번)   
한 번 들 때마다 마지막 하나가 정렬되므로 원소들이 거품이 올라오는 것처럼 보여 거품정렬이다.

거의 모든 상황에서 최악의 성능을 보여준다.  
단, 이미 정렬된 자료에서는 1번만 들면 되기 때문에 최선의 성능을 보여준다.   
이미 정렬된 자료를 정렬하는 이유는 정렬 알고리즘은 자료가 정렬되어 있는지 아닌지는 모르고 작동하기 때문에 의미가 있다.  
가장 손쉽게 구현하여 사용할 수 있지만, 만들기가 쉽고 직관적일 뿐이지 알고리즘적 관점에서 보면 대단히 비효율적인 정렬 방식이다.  
다른 몇 가지 정렬 방식과 비교해도 효율이 극히 안 좋다.

# 1.1.2. 칵테일 정렬
![칵테일 정렬](/img/cocktail_sort0.gif)

칵테일 정렬의 실행 과정을 표현한 그림.

셰이커 정렬(shaker sort)라고도 한다.  
홀수 번째 돌 때는 앞부터, 짝수 번째는 뒤부터 훑는 정렬 방식이다.  
마지막과 처음이 번갈아가며 정렬된다.  

# 1.1.3. 콤브 정렬
기본 형태는 버블 정렬과 같지만 예를 들어 처음에 a[0]에서 10칸 띄워서 a[11]과 비교해서 치환하는 식으로 대상을 띄웠다가 한 바퀴 돌면 띄우는 간격을 좁혀서 정렬하는 방식이다.  
이렇게 하면 버블 정렬과 다를 게 없어졌을 시점엔 정렬이 거의 끝나 있는데, 이 단계까지 가는 동안 모양이 마치 닭의 볏을 닮았다 하여 콤브 정렬이라는 이름이 붙었다.   
단순히 보면 콤브 정렬이 버블 정렬보다 좋아 보이지만 단점이 있는데 버블 정렬이 stable sort이지만 콤브 정렬은 stable sort가 아니다.

# 1.1.4. 선택 정렬
![선택 정렬](/img/selection_sort0.gif)

선택 정렬의 실행 과정을 표현한 그림.

버블 정렬이 비교하고 바로 바꿔 넣는 걸 반복한다면 이쪽은 일단 1번째부터 끝까지 훑어서 가장 작은 게 1번째, 2번째부터 끝까지 훑어서 가장 작은 게 2번째...해서 (n-1)번 반복한다.   
어찌 보면 인간이 사용하는 정렬 방식을 가장 많이 닮았다.   
어떻게 정렬이 되어 있든 일관성 있게 n(n - 1) / 2에 비례하는 시간이 걸린다는 게 특징이다.  
또한, 버블 정렬보다 두 배 정도 빠르다.

파생형으로 이중 선택 정렬(Double Selection Sort)도 있다.  
이쪽은 끝까지 훑어서 최솟값과 최댓값을 동시에 찾아낸 뒤 최솟값은 1번째와 바꾸고 최댓값은 끝과 바꾼 다음 훑는 범위를 양쪽으로 한 칸씩 줄여서 반복하는 방식이다.  
즉 선택 정렬에 칵테일 정렬 방식을 도입한 것이다.  
이 방법을 사용하면 반복 횟수가 반으로 줄어든다.

# 1.1.5. 삽입 정렬
![삽입 정렬](/img/insertion_sort0.gif)

삽입 정렬의 실행 과정을 표현한 그림.

k번째 원소를 1부터 k-1까지와 비교해 적절한 위치에 끼워넣고 그 뒤의 자료를 한 칸씩 뒤로 밀어내는 방식으로, 평균적으론 O(n^2)중 빠른 편이나(최악의 경우가 n(n - 1) / 2에 비례한다.) 자료구조에 따라선 뒤로 밀어내는데 걸리는 시간이 크며, 위의 그림처럼 작은 값이 뒤쪽에 몰려있으면(내림차순의 경우 큰 값이 뒤쪽에 몰려있으면) 굉장히 비효율적이다.   
다만 이미 정렬되어 있는 자료구조에 자료를 하나씩 삽입/제거하는 경우에는 현실적으로 최고의 정렬 알고리즘이 되는데, 탐색을 제외한 오버헤드가 매우 적기 때문이다.

그 밖에도 배열이 작을 경우에도 상당히 효율적이다.   
일반적으로 빠르다고 알려진 알고리즘들도 배열이 작을 경우에는 대부분 삽입 정렬보다 느리다.   
따라서 고성능 알고리즘들 중에서는 배열의 사이즈가 클때는 O(n log n) 알고리즘을 쓰다가 정렬해야 할 부분이 작을때는 삽입 정렬로 전환하는 것들도 있다.

파생형으로 이진 삽입 정렬(Binary Insertion Sort)이 있다.  
이진 탐색을 활용해 새로운 원소가 위치할 곳을 미리 찾아서 정렬하는 방식이다.   
원소 크기를 비교하는 조건 부분을 log n 수준으로 낮춰 조금은 더 빠르게 수행할 수 있다는 장점이 있다.

# 1.2. O(n log n)
이 알고리즘은 최선이나 평균적으로나 O(n log n)의 성능을 나타낸다.   
최악의 상황에서도 병합 정렬이나 힙 정렬은 O(n log n)을 유지하는 반면 순수한 퀵 정렬은 오히려 O(n^2)으로 뒤진다.   
하지만 실제로는 O(n log n)일때는 퀵 정렬이 보통 제일 빠르기 때문에 퀵 정렬을 조금 개량해서 최악의 경우가 발생하지 않도록 코드를 작성하거나 나쁜 경우다 싶으면 힙 정렬로 전환하게끔 코드를 짠다.   
이 알고리즘들은 서로만의 특유한 성질과 장단점이 있다.

# 1.2.1. 병합 정렬
![병합 정렬](/img/merge_sort0.gif)

병합 정렬의 실행 과정을 표현한 그림.

개발자는 존 폰 노이만으로 원소 개수가 1 또는 0이 될 때까지 두 부분으로 쪼개기를 반복해서 자른 순서의 역순으로 크기를 비교해 병합해 나간다.  
병합된 부분 안은 이미 정렬되어 있으므로 전부 비교하지 않아도 제자리를 찾을 수 있다.   
대표적인 분할 정복 알고리즘이다.

성능은 퀵 정렬보다 전반적으로 뒤떨어지고, 데이터 크기만한 메모리가 더 필요하지만(추가적인 메모리 없이 병합 정렬을 수행할 수도 있지만, 그 경우 시간복잡도가 O(n(log n)^2)으로 늘어난다.) 최대의 장점은 데이터의 상태에 별 영향을 받지 않는다는 점(stable sort. 정렬을 해도 같은 값의 앞뒤 순서가 바뀌지 않는 정렬 알고리즘을 보고 stable하다고 한다.)이다.   
힙이나 퀵의 경우에는 배열 A[25]=100, A[33]=100인 정수형 배열을 정렬한다고 할 때, 33번째에 있던 100이 25번째에 있던 100보다 앞으로 오는 경우가 생길 수 있다.   
그에 반해서 병합 정렬은 이런 일이 발생하지 않는다.   
기본적으로 병합 정렬은 쪼갠 후 두 값을 비교할 때 값이 같으면 정렬하지 않게 설계되기 때문이다.   
이 특성이 중요한 이유는, 실제 상황에서 여러 기준으로 정렬했을 때 동일 값에 대해선 기존 기준의 정렬 순서가 유지되어야 한다.  
예를 들어 동점일 경우 생년월일 기준으로 수상자를 뽑는 규정이 있는 대회에서 참가자들을 생년월일 순서대로 정렬해놓고 시험점수 기준으로 다시 정렬할 경우, 병합 정렬은 동점자들끼리 생년월일 순서대로 정렬된 것이 100% 유지된다.  
정렬되어 있는 두 배열을 합집합할 때 이 알고리즘의 마지막 단계만을 이용하면 가장 빠르게 정렬된 상태로 합칠 수 있다.

그림으로 병합 정렬 과정을 도식화 하면 다음과 같다.

![병합 정렬 도식화](/img/merge_sort1.webp)

이 그림에서 분할 정복으로 일정하게 정렬이 이뤄지는 병합 정렬의 특징을 잘 파악할 수 있다.  
[38, 27, 43, 3, 9, 82, 10] 인 입력값은 [38, 27, 43, 3] 과 [9, 82, 10] 두 부분으로 분할, 다시 [38, 27], [43, 3], [9, 82], [10] 네 부분으로 분할하는 동작을 반복하여 더 이상 쪼갤 수 없을 때까지 계속해서 분할한 후, 분할이 끝나면 정렬하면서 정복해 나간다.

## 구현
```c#
using System;
using System.Collections;

public static class MergeSort
{
  // 정렬할 배열
  private static int[] Array { get; set; }

  // 정렬 함수
  public static void Sort(int[] arr)
  {
    // 정렬할 배열 초기화
    Array = arr;
    // 첫 번째 분할 실행
    Divide(0, arr.Length - 1);
  }

  // 분할 함수
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

  // 병합 함수
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
```