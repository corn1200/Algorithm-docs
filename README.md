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
    * [1.2.2. 힙 정렬](#122-힙-정렬)
    * [1.2.3. 퀵 정렬](#123-퀵-정렬)
    * [1.2.4. 트리 정렬](#124-트리-정렬)
  * [1.3. 하이브리드](#13-하이브리드)
    * [1.3.1. 팀 정렬](#131-팀-정렬)
    * [1.3.2. 인트로 정렬](#132-인트로-정렬)
  * [1.4. 기타](#14-기타)
    * [1.4.1. 기수 정렬](#141-기수-정렬)
    * [1.4.2. 카운팅 정렬](#142-카운팅-정렬)

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

### 구현
```c#
public static class MergeSort
{
  private static int[] Array { get; set; }
  // ...
}
```
인스턴스 생성 없이 병합 정렬을 수행하도록 병합 정렬 클래스를 static으로 작성한다.   
정렬할 배열을 임시 저장할 필드를 가진다.

```c#
// ...
public static void Sort(int[] arr)
{
  Array = arr;
  Divide(0, arr.Length - 1);
}
// ...
```
사용자가 실제 호출하는 정렬 메서드를 작성한다.  
정렬할 배열을 파라미터로 받고 임시 배열 필드를 초기화한다.  
0부터 마지막 인덱스까지를 범위로 첫 번째 분할을 실행한다.

```c#
// ...
private static void Divide(int left, int right)
{
  if (left < right)
  {
    int middle = (left + right) / 2;

    Divide(left, middle);
    Divide(middle + 1, right);

    Merge(left, middle, right);
  }
}
// ...
```
분할 메서드를 작성한다.   
병합 및 정렬을 실행하기 위한 분할을 진행한다.   
파라미터로 왼쪽 인덱스(시작)와 오른쪽 인덱스(끝)를 받는다.  
왼쪽 인덱스가 오른쪽 인덱스보다 작을 경우에 현재 범위에서 더 분할이 가능하므로 아래 동작을 수행한다.   

1. 왼쪽, 오른쪽의 중앙을 구한다.  
2. 왼쪽부터 중앙까지를 범위로 하는 분할을 실행한다.
3. 중앙보다 1칸 뒤 위치부터 오른쪽까지를 범위로 하는 분할을 실행한다.

2번, 3번의 재귀적 분할 동작이 끝난 후 현재 위치로 돌아와 왼쪽, 중앙, 오른쪽을 기준으로 병합을 진행한다.

```c#
// ...
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
// ...
```
병합 메서드를 작성한다.   
왼쪽부터 중앙까지, 중앙보다 1칸 뒤 위치부터 오른쪽까지 요소를 각각의 배열에 나눠 복사한다.    
분할한 왼쪽, 오른쪽 배열의 현재 인덱스와 정렬할 배열의 시작 인덱스를 초기화한다.  
왼쪽 배열을 모두 복사하거나 오른쪽 배열을 모두 복사할 때까지 아래 동작을 반복한다.

1. 현재 왼쪽 요소가 오른쪽 요소보다 작거나 같을 경우 왼쪽 요소를 정렬할 배열에 저장하고 왼쪽 인덱스를 증가 시킨다.
2. 현재 오른쪽 요소가 왼쪽 요소보다 작을 경우 오른쪽 요소를 정렬할 배열에 저장하고 오른쪽 인덱스를 증가 시킨다.
3. 정렬할 배열의 시작 인덱스를 증가 시킨다.

위 반복이 종료된 후 왼쪽, 오른쪽 배열의 남은 요소를 정렬할 배열에 저장한다.   
재귀적 분할 작업 중 이전에 분할된 범위는 이미 정렬이 끝난 상태이기 때문에 남은 한 쪽의 배열 요소를 비교 없이 저장해도 정렬에 문제가 생기지 않는다.

[파일](/sample_code/MergeSort.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 병합 정렬 클래스
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
```
</details>

# 1.2.2. 힙 정렬
![힙 정렬](/img/heap_sort0.gif)

힙 정렬의 실행 과정을 표현한 그림.

1. 원소들을 전부 힙에 삽입한다.
2. 힙의 루트에 있는 값은 남은 수들 중에서 최솟값(혹은 최댓값)을 가지므로 루트를 출력하고 힙에서 제거한다.
3. 힙이 빌 때까지 2의 과정을 반복한다.

선택 정렬과 거의 같은 알고리즘으로, 단지 가장 큰 원소를 뒤로 보내는 데에 단순히 매번 반복 순회하며 알아내느냐 힙을 사용하여 알아내느냐가 차이점이다.

힙 정렬은 추가적인 메모리를 전혀 필요로 하지 않는다는 점과, 최악의 경우에 O(n^2)의 성능을 내는 퀵 정렬과 달리 항상 O(n log n) 시간복잡도의 성능을 발휘하는 장점이 있다.   
하지만 실제 코드를 짜서 비교해 보면 퀵 정렬이 힙 정렬보다 일반적인 경우에 빠르게 동작한다.  
퀵 정렬의 경우는 대개 원소들끼리 근접한 메모리 영역에 붙어 있는 배열을 사용하기 때문에 일반적으로 캐시 친화적이지만 힙 정렬의 원소들은 좀 더 흩어져 있는 경우가 많아서 캐시 친화도가 떨어지는 문제가 있다.  
또한 힙 정렬은 일반적으로 포인터 연산을 많이 사용하기 때문에 걸리는 오버헤드도 무시할 수 없는 수준이다.

퀵 정렬의 경우 피벗을 잡는 전략에 어느 정도의 휴리스틱이 들어가야 최악의 경우를 회피할 수 있으나 힙 정렬은 휴리스틱이 필요없이 항상 일정한 성능을 보이는 장점이 있다.  
알고리즘을 변형하지 않고 각종 하드웨어 가속도 전혀 고려하지 않고 알고리즘이 정의하는 최소한만 구현할 경우 힙 정렬이 가장 안정적인 성능을 보인다.

### 구현
```c#
public static class HeapSort
{
  private class Heap<T>
  {
    // ...
  }
  // ...
}
```
힙 정렬 클래스와 내부적으로 사용할 [최대 힙 클래스](https://github.com/corn1200/Data-structure-docs#7-%ED%9E%99)를 작성한다.  

```c#
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
```
정렬 실행 메서드를 작성한다.  
최대 힙 객체를 생성하고 정렬할 배열의 요소들을 힙에 추가한다.   
최대 힙이기 때문에 요소를 추가하면서 루트 노드에 가장 큰 값이 위치하게 된다.   
모든 배열 요소를 힙에 추가한 후, 힙의 모든 데이터를 배열에 역순으로 저장한다.   
힙에서 데이터를 제거하면 루트 노드를 삭제 및 반환하며, 다시 가장 큰 값이 루트 노드에 위치하도록 위치를 변경한다.

[파일](/sample_code/HeapSort.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 힙 정렬 클래스
public static class HeapSort
{
  // 정렬 메서드
  public static void Sort(int[] arr)
  {
    // 최대 힙 객체 생성
    Heap<int> heap = new Heap<int>();

    // 힙에 모든 배열 요소 추가
    foreach (int i in arr)
    {
      heap.Add(i);
    }

    // 힙 데이터를 제거하며 배열에 저장
    for (int i = arr.Length - 1; i >= 0; i--)
    {
      arr[i] = heap.Remove();
    }
  }

  // 최대 힙 클래스
  private class Heap<T>
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
```
</details>

# 1.2.3. 퀵 정렬
![퀵 정렬](/img/quick_sort0.gif)

퀵 정렬의 실행 과정을 표현한 그림.

토니 호어가 1959년에 개발한 알고리즘이며, 퀵이라는 이름에서 알 수 있듯이 평균적인 상황에서 최고의 성능을 나타낸다.  
컴퓨터로 가장 많이 구현된 정렬 알고리즘 중 하나이다.  
C, C++, PHP 등의 언어에서 제공하는 정렬 함수에서 퀵 정렬 혹은 퀵 정렬의 변형 알고리즘을 사용한다.   
방식은 적절한(의사난수를 이용할 수도 있으나 대개 중위법을 사용하는 게 더 빠르다.) 원소 하나를 기준(피벗, pivot)으로 삼아 그보다 작은 것을 앞으로 빼내고 그 뒤에 피벗을 옮겨 피벗보다 작은 것, 큰 것으로 나눈 뒤 나누어진 각각에서 다시 피벗을 잡고 정렬해서 각각의 크기가 0이나 1이 될 때까지 정렬한다.   
이렇게 피벗을 잡고 이보다 작은 원소들을 왼쪽으로, 보다 큰 원소들을 오른쪽으로 나누는 걸 partition step이라 한다.  
퀵 정렬에도 이 partition step을 어떻게 하느냐에 따라 바리에이션이 매우 많으며, 성능 차이도 날 수 있다.

![퀵 정렬](/img/quick_sort1.webp)

퀵 정렬의 가장 기본이 되는 분할 알고리즘인 로무토 파티션을 도식화 하면 위 그림과 같다.  
피벗은 맨 오른쪽 값을 기준으로 하며, 이를 기준으로 2개의 포인터가 이동해서 오른쪽 포인터의 값이 피벗보다 작다면 서로 스왑하는 형태로 진행된다.  
오른쪽 right 포인터가 이동하면서 피벗의 값이 오른쪽 값보다 더 클 때, 왼쪽과 오른쪽의 스왑이 진행된다.   
스왑 이후에는 왼쪽 left 포인터가 함께 이동 한다.  
여기서 피벗의 값은 4이므로, 오른쪽 포인터가 끝에 도달하게 되면 4 미만인 값은 왼쪽으로, 4 이상인 값은 오른쪽에 위치하게 된다.  
그리고 왼쪽 포인터의 위치로 피벗 아이템이 이동한다.   
즉 그림에서 최종 결과인 8)을 보면, 4를 기준으로 작은 값은 왼쪽에, 큰 값은 오른쪽으로 분할되어 있고, 피벗이 그 중앙으로 이동하는 모습을 확인할 수 있다.  
이렇게 계속 분할하면서 정복을 진행하여 코드 기준으로 left < right를 만족하지 않을 때까지, 즉 서로 위치가 역전할 때까지 계속 재귀로 반복되면서 정렬이 완료된다.

최악의 경우에는 시간복잡도가 O(n^2)가 되는데, 피벗을 최솟값이나 최댓값으로 계속해서 잡게 되는 경우에 그렇다.  
대표적인 예로는 피벗을 항상 배열의 첫 번째 원소를 잡도록 구현했을 때 이미 정렬된 배열을 정렬할 경우.  
다음 그림과 같이 전혀 분할이 진행되지 않고 하나씩 정렬되는 모습을 확인할 수 있다.   
힙 정렬이나 병합 정렬은 이런 경우가 없지만, 데이터가 극단적이면 대충 구현된 퀵 정렬은 최악의 결과를 초래한다.

![퀵 정렬](/img/quick_sort2.webp)

이를 방지하기 위하여 여러 기법들이 개발 되었는데, 대표적인 것이 피벗을 랜덤으로 잡는 것(Random Quick sort).   
또는, 무조건 배열의 위치상 중간에 있는 원소를 피벗으로 잡거나(이 방법을 사용할 경우 거의 정렬되거나 거의 역정렬된 리스트도 아주 빨리 정렬이 가능하다.) 배열 중에 3개나 9개의 원소를 골라서 이들의 중앙값을 피벗으로 고르는 것이다. (gcc나 Visual C++에 구현된 방법이 바로 이것.)   
이런 방법들을 사용하더라도 최악의 경우가 나올 수는 있지만 그 경우가 극히 드물게 된다.   
다만 배열이 단순하게 비교 가능한 숫자가 아니라면 중앙값 피벗 방법이 비효율적일 수도 있다.   
예를 들어 비교하는데 연산이 아주 많이 들어가는 객체 또는 데이터베이스일 경우 무작위 또는 중간에 있는 원소를 피벗으로 잡는게 효율적이다.

피벗을 랜덤으로 정한다고 해도 정렬 시간이 O(n^2)으로 나쁜 경우가 나올 수 있다.  
그래서 이런 나쁜 케이스들을 완전히 없애고 싶다면 순수 퀵 소트 보다는 특수한 상황이 나왔을 때 다른 효율적인 정렬 알고리즘을 섞어서 쓰는 하이브리드 퀵 소트가 좋다.   
그래서 재귀 깊이가 어느 제한 이상으로 깊어질 경우 힙 정렬 알고리즘을 사용하여 항상 O(n log n)을 보장해주는 방법도 많이 쓰인다. (인트로 정렬)

현존하는 컴퓨터 아키텍처상에서 비교 연산자를 이용하여 구현된 정렬 알고리즘 중 가장 고성능인 알고리즘이 바로 이 퀵 정렬이다.   
단 데이터에 접근하는 시간이 오래 걸리는 외부 기억장소(하드디스크 등)에서 직접 정렬을 수행할 경우에는 병합 정렬이 더 빠른 것으로 알려져 있다.  
요즘에는 디스크에서 데이터를 블럭 단위로 읽어서 각각을 퀵 정렬한 뒤 정렬된 두 블럭을 병합 정렬하는 식으로 알고리즘을 설계한다.

### 구현
```c#
public static class QuickSort
{
  private static int[] Array { get; set; }
  // ...
}
```
퀵 정렬 클래스를 작성한다.  
정렬할 배열을 필드로 가진다.

```c#
public static void Sort(int[] array)
{
  Array = array;

  Sort(0, array.Length - 1);
}
```
외부 사용자가 호출하는 용도의 정렬 시작 메서드를 작성한다.  
정렬할 배열을 초기화한다.   
정렬 범위를 0번 인덱스부터 배열의 마지막 인덱스까지로 정한다.

```c#
private static void Sort(int left, int right)
{
  if (left < right)
  {
    int pivotIndex = Partition(left, right);

    Sort(left, pivotIndex - 1);
    Sort(pivotIndex + 1, right);
  }
}
```
내부 동작용 정렬 메서드를 작성한다.   
정렬 범위(왼쪽, 오른쪽)가 유효한 경우에만 아래 동작을 실행한다.
1. 왼쪽, 오른쪽 범위 내의 값들을 파티션 분할 동작 후 피벗이 이동한 위치를 반환한다.
2. 왼쪽부터 피벗 전까지를 범위로 정렬 메서드를 실행한다.
3. 피벗 이후부터 오른쪽까지를 범위로 정렬 메서드를 실행한다.

```c#
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
```
파티션 분할 메서드를 작성한다.  
분할 범위 내에 가장 오른쪽 요소를 피벗 값으로 선정한다.   
피벗 값 미만 요소를 가리킬 인덱스 변수를 선언한다.  
왼쪽부터 오른쪽 범위까지 모든 요소를 순회하며, 현재 요소가 피벗 미만 값일 경우 피벗 미만 값을 가리키는 인덱스를 증가시키고 해당 위치의 요소와 현재 요소와 교환한다.   
피벗 미만 요소 인덱스는 피벗 미만 값일 경우에만 증가했으므로, 인덱스를 1 증가 시킨 위치의 요소는 피벗 미만 값이 아니며 해당 요소가 피벗 미만 값인 현재 요소와 위치를 교환하게 된다.   
모든 요소를 순회한 후 마지막 피벗 미만 요소 인덱스 1 증가 시킨 위치에 피벗을 이동 시키고 해당 위치를 반환한다.  

```c#
private static void Swap(int i, int j)
{
  int temp = Array[i];
  Array[i] = Array[j];
  Array[j] = temp;
}
```
배열 요소의 위치 교환하는 메서드를 작성한다.

[파일](/sample_code/HeapSort.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
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
```
</details>

# 1.2.4. 트리 정렬
이진 탐색 트리를 만들어 정렬하는 방식이다.  
힙 정렬과 비슷해 보이지만 차이가 있는데, 정렬될 자료의 각 원소 크기에 따라 부모 노드의 왼쪽 자식이 되느냐 오른쪽 자식이 되느냐가 갈린다는 차이가 있다.

1. 정렬될 배열의 맨 첫 값이 루트 노드가 된다.
2. 다음 값부터는 기존 노드 값과 비교한다.   
루트 노드에서 출발해서 추가될 노드 값이 기존 노드 값보다 작은 경우는 왼쪽 자식을, 기존 노드 값보다 크거나 같은 경우는 오른쪽 자식을 찾는다.   
내림차순은 반대로 기존 노드 값보다 크면 왼쪽, 작거나 같으면 오른쪽을 찾으면 된다. 
3. 위 2에서 해당 방향의 자식 노드가 없으면 그 방향의 자식 노드로 추가한다.  
있으면 그 방향의 자식 노드로 가서 크기를 비교하고 위 2와 같은 방법으로 해당 방향의 자식 노드가 있으면 계속 그 방향으로 가서 조사하고 없으면 그 방향의 자식 노드로 추가한다.   
4. 모든 값이 노드로 추가되었으면 해당 트리를 중위 순회 방식으로 순회하여 그 순서대로 값을 정렬해 나간다.

예를 들어, [4, 6, 1, 7, 5, 8, 2, 3]을 트리 정렬로 정렬하기 위해 이진 트리를 만들면 아래 그림과 같이 된다.   

![트리 정렬](/img/tree_sort0.png)

이 이진 트리를 중위 순회 방식(왼쪽 자식 - 자신 - 오른쪽 자식 순)으로 순회하면(위 그림에서 무지개색 순으로 순회한다) [1, 2, 3, 4, 5, 6, 7, 8]이 된다.  

최대값과 최소값을 탐색할때 매우 효율적이다.   

이를 배열로도 구현이 가능하나(예를 들면 N번째 노드의 왼쪽 노드를 N*2+1, 오른쪽 노드를 N*2번째 값이라고 생각하고 프로그램을 구현할 수 있다.), 입력값이 적은것이 아니라면 비효율적이다. (배열로 이를 구현할 경우 최악의 경우 공간복잡도가 O(2^n)이 된다.)

### 구현
```c#
public static class TreeSort
{
  private static int[] Array { get; set; }
  private static int Index { get; set; }

  private class Node
  {
    // ...
  }

  private class BinarySearchTree 
  {
    // ...
  }
}
```
트리 정렬 클래스를 작성한다.  
정렬할 배열과 배열 인덱스를 필드로 가진다.  
내부적으로 사용할 [이진 탐색 트리 클래스](https://github.com/corn1200/Data-structure-docs#611-%EC%9D%B4%EC%A7%84-%ED%83%90%EC%83%89-%ED%8A%B8%EB%A6%AC)를 작성한다.

```c#
public static void Sort(int[] arr)
{
  BinarySearchTree tree = new BinarySearchTree();

  Array = arr;
  Index = 0;

  foreach (int item in Array)
  {
    tree.Add(item);
  }

  tree.InOrderTraversal();
}
```
정렬 메서드를 작성한다.   
이진 탐색 트리 객체를 선언하고 정렬할 배열과 인덱스를 초기화한다.   
모든 배열 요소를 이진 탐색 트리에 삽입한 후 중위 순회 방식으로 트리에 삽입된 요소를 탐색하며 배열에 다시 저장한다.  
왼쪽 - 자신 - 오른쪽 순서로 노드를 방문하기 때문에 정렬된 데이터를 얻을 수 있다.

[파일](/sample_code/TreeSort.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
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
```
</details>

# 1.3. 하이브리드

# 1.3.1. 팀 정렬
[![팀 정렬](https://img.youtube.com/vi/NVIjHj-lrT4/0.jpg)](https://youtu.be/NVIjHj-lrT4)
병합 + 삽입 정렬.   
팀 정렬은 학계에서 받아들여질 만한 우아한 알고리즘을 목표로 하기보다는, '실제 데이터는 대부분 이미 정렬되어 있을 것이다'라고 가정하고 실제 데이터에서 고성능을 낼 수 있도록 설계한 알고리즘이다.  
데이터가 엉망으로 뒤죽박죽 섞여 있는 일은 실제로는 거의 일어나지 않은 것이라 가정한 셈이다.   
팀 정렬은 개별적인 단일 알고리즘이 아니라 삽입 정렬과 병합 정렬을 휴리스틱하게 적절히 조합해 사용하는 정렬 알고리즘이다.  
병합 정렬은 원소의 개수가 적을 때 오버헤드가 발생하기 때문에 파티션 크기가 특정 값 이하(보통 16 또는 32)가 되면 삽입 정렬을 사용한다.   
이외에도 곳곳에 어느정도 정렬된 데이터에서 이득을 볼 수 있는 휴리스틱이 더 들어가 있다.   
병합 정렬과 비슷한 특징을 가지며 대부분의 경우 더 빠르다.   

현재 팀 정렬은 안드로이드 뿐만 아니라 구글 크롬, 애플의 스위프트 등 현업에서 현업에서 다양하게 활용된다.

# 1.3.2. 인트로 정렬
[![인트로 정렬](https://img.youtube.com/vi/67ta5WTjjUo/0.jpg)](https://youtu.be/67ta5WTjjUo)
퀵 + 힙 정렬.   
기본적으로 퀵 정렬을 하지만 재귀 깊이가 깊어지는 경우 힙 정렬을 사용한다.   
이 역시 많이 쓰이는 방식이며, 팀 정렬처럼 파티션이 작을 때 삽입 정렬로 전환하는 추가적인 최적화를 해주는 경우도 있다.   

C++의 std::sort()에서 가장 널리 쓰이는 정렬 방법이며 C#에서도 사용한다.

# 1.4. 기타
특정한 상황에서는 O(n log n) 보다 더 빠른 O(n)으로 정렬을 실행할 수도 있다.

# 1.4.1. 기수 정렬
![기수 정렬](/img/radix_sort0.gif)
기수 정렬 알고리즘 시각화.

O(kn) k는 데이터의 자릿수를 의미한다.

여태까지 나온 알고리즘은 모두 데이터끼리의 직접적인 비교를 이용하는데, 이렇게 데이터끼리 직접적인 비교를 하여 정렬할 경우 시간복잡도는 O(n log n) 보다 작아질 수 없다.  
이 기수 정렬은 자릿수가 있는 데이터(정수, 문자열 등)에서만 수행이 가능하며, 데이터끼리의 직접적인 비교 없이 정렬을 수행한다.  
비교를 이용한 정렬이 아니기 때문에 k가 상수일 경우 시간복잡도가 O(n)으로 퀵 정렬보다 빠른 시간복잡도가 나오는 것이 가능하다.  
다만 이 알고리즘은 자릿수가 적은 4바이트 정수 등에서나 제대로 된 성능을 발휘할 수 있으며, 자릿수가 무제한에 가까운 문자열 정렬 등에 사용할 경우 오히려 퀵 정렬보다 느릴 수 있고, 부동 소수점의 경우는 부호여부, 지수부, 가수부에 대해 각각 기수 정렬을 실행해야 한다.

1. 데이터가 x진법이라고 가정한다.
2. 0번부터 x-1번까지의 리스트를 만든다. 
3. 각 데이터를 순서대로 현재 자릿수의 숫자가 가리키는 리스트에 밀어넣고, 리스트를 0번부터 x-1번까지 순서대로 이어붙인다. 
4. 이 과정을 가장 낮은 자릿수부터 가장 높은 자릿수까지 반복한다.

위 과정을 끝내면 기수 정렬이 끝나게 된다.

(예시) 10, 5, 15, 234, 1: 10진법, 최대 3자리 수인 정수들을 정렬한다.  
편의상 010, 005, 015, 234, 001로 표기.

10^0의 자리: 0)010, 1)001, 4)234, 5)005, 015. 순서대로 이어붙이면 010, 001, 234, 005, 015.  
10^1의 자리: 0)001, 005, 1)010, 015, 3)234. 순서대로 이어붙이면 001, 005, 010, 015, 234.  
10^2의 자리: 0)001, 005, 010, 015, 2)234. 순서대로 이어붙이면 001, 005, 010, 015, 234.

마지막 자리까지 과정을 거치면 정렬된 결과인 1, 5, 10, 15, 234가 나온다.   
실제 프로그램에서 정수를 정렬하는 코드를 작성하는 경우, 10진법 대신 컴퓨터가 바이트 단위로 처리하기 쉬운 2진법을 사용하고, 각 자릿수를 정렬하는 과정은 카운팅 정렬을 이용하는 경우가 많다.  
그렇게 코드를 작성하면 퀵 정렬보다도 훨씬 빠른 속도로 정수를 정렬할 수 있다.  
다만 위에 설명한 대로 이는 자릿수가 적은 상황에서만 그렇고 대부분의 경우에는 그렇지 않다.

그 이유는 시간복잡도가 엄밀하게는 O(n)이 아니라 O(kn)이기 때문이다.   
해당 데이터의 자릿수(k)는 상수로 간주하지만 어쨌든 k는 log에 해당되므로(x진법을 사용하고 데이터의 최댓값이 m이라면 k = log_x m 으로 나타낼 수 있다.), 데이터의 수(n)가 데이터의 최댓값보다 더 큰 경우가 아니면 k(자릿수)가 log n 보다 크기 때문이다.

# 1.4.2. 카운팅 정렬
O(n + k) k는 데이터의 최댓값을 의미한다.  

카운팅 정렬은 가장 큰 데이터에 따라 효율이 좌지우지된다.  
쉽게 설명하자면 특정 데이터의 개수(1이 두 개 있다면 2)를 데이터의 값에 대응하는 위치에 저장한 뒤, 자신의 위치에서 앞에 있던 값을 모두 더한 배열을 만든 뒤, 거기서 데이터가 들어가야 할 위치를 찾아내는 정렬 알고리즘이다.   
이 경우에 데이터의 최댓값을 k라 두면, 시간복잡도는 O(n + k)이다.  
하지만, 만약 k가 억 단위를 넘어간다면(데이터가 항상 작은 값만 들어오리라는 보장이 없기 때문에 범용적으로 쓰기엔 문제가 있다. 또한 이 경우엔 메모리 효율성도 떨어진다.) n이 아무리 작아도 동작시간이 크다.   
그럴 땐 위의 정렬들을 사용하는 게 바람직하다.   
반대로 k가 매우 작다면, 오히려 선형 시간의 효과를 볼 수 있다.  
즉, k가 작다는 조건이라면 매우 효율적인 정렬이다.   
또한 카운팅 정렬은 배열을 사용하는 특성상, 정수라는 전제를 깔고 있다.

### 실행 과정
1. 자료를 탐색해서 그 최댓값을 구한다.
    - input = [1, 5, 4, 6, 3, 7, 8, 9, 10, 2]
    - 최댓값: k = 10
2. k+1 만큼의 크기로 모든 자료가 0으로 초기화된 배열을 생성한다. 
    - 배열 counts = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] (11개)
3. input 의 모든 원소 n에 대하여 counts의 n에 대응하는 곳에 +1을 해준다.
    - counts = [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    - 이때 counts[n]은 배열 input에 n이 몇 개 있는지를 의미한다.
4. counts[i] += counts[i-1]의 점화식을 1부터 k의 위치까지 행한다.
    - counts = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
    - 이때 counts[n]은 배열 input에 n 이하의 원소가 몇 개 있는지를 의미한다.
5. 길이가 counts[k]인 배열을 하나 더 생성한다. 
    - 배열 ans = [N, N, N, N, N, N, N, N, N, N] (10개, N은 Null)
6. counts의 input[0]에 대응하는 곳의 원소를 찾아 t로 놓는다.  
이제 ans의 t-1에 대응하는 곳에 input[0]을 저장하고, counts의 input[0]에 대응하는 곳의 값은 -1 해준다.
    - 1이 주어짐
    - counts[1] = 1
    - 대응하는 값인 1-1=0의 위치에 1을 삽입 
    - ans = [1, N, N, N, N, N, N, N, N, N]
    - counts는 [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]에서 [0, 0, 2, 3, 4, 5, 6, 7, 8, 9, 10]로 바뀜
7. 6의 과정을 남아 있는 자료에 대하여 반복한다.
    - 5가 주어짐
    - counts[5] = 5
    - 대응하는 값인 5-1=4의 위치에 5를 삽입
    - ans = [1, N, N, N, 5, N, N, N, N, N]
    - counts는 [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]에서 [0, 0, 2, 3, 4, 4, 6, 7, 8, 9, 10]로 바뀜
    - ...
8. 이런 식으로 n개의 자료를 모두 조사하면 [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] 순서로 정렬이 된다.

# 2. 탐색
트리 탐색 문제는, 그래프나 트리와 같은 자료구조로 구성되는 환경에서 목적지에 도달하기 위한 경로를 구하기 위한 문제이다. (목적지를 찾는 문제로 착각하기 쉬운데, 목적지를 탐색하는 것이 아니라, 그 과정에서 어떤 경로를 지나가면 가장 효과적으로 목적지에 도달하는가를 찾는 문제이다.)  
트리 탐색 문제는 구하는 해의 최초 시작점(Initial State), 현재 상태가 최종 도착지인지를 확인하기 위한 해 평가(Goal Test), 하나의 상태에서 다른 상태로 옮겨가기 위해 선택해야 할 행동(Successor function), 추가적으로 필요하다면 선택지마다 소요되는 비용(Path Cost) 등으로 구성된다.   
하나의 상태에서 다른 상태로 옮기기 위한 행동은 각 상태마다 다른데, 행동을 정의할때는 '어느 상태의 어떤 행동이 다른 어느 상태로 전이시킨다'라고 정의하기 때문에 사실상 행동에는 상태의 정보까지 함께 포함된다.   
트리에서는 하나의 요소를 노드라고 표현하는데 노드와 상태는 엄밀히 말하면 동의어는 아니다.   
노드는 트리의 구성요소에 불과하며, 그 안에 어떤 정보를 담고 있는지에 대해서는 정의되지 않는 단순한 자료구조의 일부이다.   

# 2.1. DFS
![DFS](/img/DFS_BFS.gif)

DFS(깊이 우선 탐색, Depth-First Search)는 그래프의 모든 노드를 탐색하는 알고리즘 중 하나이다.   
DFS는 스택(Stack) 또는 재귀 함수를 사용하여 구현할 수 있다.

DFS는 시작 노드에서부터 한 경로를 따라 더 이상 갈 수 없을 때까지 탐색하고, 더 이상 갈 수 없게 되면 이전에 방문한 노드로 돌아와 다음 가능한 경로를 탐색하는 방식으로 작동한다.   
이러한 방식으로 그래프의 깊이를 우선적으로 탐색하기 때문에 "깊이 우선 탐색"이라고 불린다.

DFS의 작동 과정은 다음과 같다:

1. 시작 노드를 방문하고, 방문한 노드를 방문한 노드 목록에 추가한다.
2. 현재 노드와 연결된 모든 인접한 노드들을 검사한다.
3. 아직 방문하지 않은 인접한 노드가 있으면, 해당 노드를 방문하고 방문한 노드 목록에 추가한 후 2번 단계를 반복한다.
4. 더 이상 방문하지 않은 인접한 노드가 없으면, 현재 노드로 돌아가 이전 노드에서 다음 가능한 인접한 노드를 검사한다.
5. 위의 과정을 반복하여 모든 노드를 방문할 때까지 탐색한다.

DFS는 그래프의 모든 노드를 방문하는데 사용될 수 있다.   
또한 DFS는 그래프에서 경로를 찾거나, 연결 요소(Connected Component)를 찾거나, 싸이클을 검사하는 등 다양한 그래프 문제를 해결하는 데에 활용될 수 있다.

하지만 DFS는 그래프가 매우 깊거나 싸이클이 있는 경우 무한 루프에 빠질 수 있으므로, 반드시 방문한 노드를 확인하고 중복 방문을 피해야 한다.   
또한 그래프가 연결되어 있지 않은 경우 모든 연결 요소에 대해 DFS를 실행해야 한다.

### 장단점
장점:   
1. 간단하고 직관적인 구현: DFS는 스택 또는 재귀 함수를 사용하여 구현하기 쉽다.  
이해하기 쉬운 알고리즘으로, 비교적 간단하게 구현할 수 있다.
2. 미로 탐색 등 경로 찾기 문제에 적합한다.  
특히 미로 탐색과 같이 최단 경로가 아니라 단순히 경로의 존재 여부를 확인하는 경우에 유용하다.
3. 메모리 요구량이 적음: DFS는 깊이 우선으로 탐색하기 때문에, 스택을 사용하여 탐색 경로를 기억하면 된다.  
따라서, 메모리 요구량이 비교적 적다.

단점:
1. 무한 루프에 빠질 수 있음: DFS는 그래프에서 싸이클이 있는 경우 무한 루프에 빠질 수 있다.  
따라서, 방문한 노드를 확인하고 중복 방문을 피해야 한다.
2. 최단 경로를 보장하지 않음: DFS는 깊이 우선으로 탐색하며, 이로 인해 처음으로 목표 노드를 찾았을 때 최단 경로가 아닐 수 있다.  
최단 경로를 찾아야 하는 문제에는 BFS(너비 우선 탐색)가 보다 적합하다.
3. 그래프가 큰 경우 비효율적일 수 있음: 그래프가 매우 크고 깊은 경우, DFS는 모든 노드를 방문하며 탐색하는데에 시간이 오래 걸릴 수 있다.   
이런 경우에는 다른 탐색 알고리즘을 고려해야 한다.

DFS는 간단하고 직관적인 알고리즘으로 경로 찾기 문제에 유용하게 사용될 수 있지만, 그래프의 특성과 문제의 요구에 따라 적합한 탐색 알고리즘을 선택해야 한다.

### 구현
[그래프 구현 코드](https://github.com/corn1200/Data-structure-docs/blob/main/sample_code/Graph.cs)

```c#
public static class DFS<T>
{
  private static List<Node<T>> Visited { get; set; }
  // ...
}
```
DFS 클래스를 작성한다.  
방문한 노드들을 리스트에 저장한다.

```c#
// ...
public static void Search(Node<T> start)
{
  Visited = new List<Node<T>>();

  VisitNode(start);
}
// ...
```
외보 호출용 탐색 메서드를 작성한다.   
방문한 노드를 저정할 변수를 초기화하고, 시작 노드부터 차례로 방문한다.

```c#
// ...
private static void VisitNode(Node<T> node)
{
  Visited.Add(node);

  Console.Write(node.Data + " ");

  foreach (Node<T> item in node.Neighbors)
  {
    if (!Visited.Contains(item))
    {
      VisitNode(item);
    }
  }
}
// ...
```
노드 방문 메서드를 작성한다.  
방문한 노드 리스트에 현재 노드를 추가하고 현재 노드의 값을 출력한다.  
현재 노드의 이웃 노드 중에 아직 방문한 노드가 없을 경우 해당 노드를 방문한다.

[파일](/sample_code/DFS.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// DFS 클래스
public static class DFS<T>
{
  // 방문한 노드 리스트
  private static List<Node<T>> Visited { get; set; }

  // DFS 탐색 메서드
  public static void Search(Node<T> start)
  {
    // 방문한 노드 리스트 초기화
    Visited = new List<Node<T>>();

    // 노드 방문 실행
    VisitNode(start);
  }

  // 노드 방문 메서드
  private static void VisitNode(Node<T> node)
  {
    // 방문한 노드를 리스트에 추가
    Visited.Add(node);

    // 방문한 노드 출력
    Console.Write(node.Data + " ");

    // 방문한 노드의 이웃 노드들에 순차 접근
    foreach (Node<T> item in node.Neighbors)
    {
      // 방문한 적 없는 노드일 경우 실행
      if (!Visited.Contains(item))
      {
        // 해당 노드 방문 실행
        VisitNode(item);
      }
    }
  }
}
```
</details>

# 2.2. BFS
![BFS](/img/DFS_BFS.gif)

BFS(너비 우선 탐색, Breadth-First Search)는 그래프의 모든 노드를 탐색하는 알고리즘 중 하나이다.   
BFS는 큐(Queue)를 사용하여 구현할 수 있다.

BFS는 시작 노드에서부터 한 단계씩 떨어진 노드들을 먼저 탐색하는 방식으로 작동한다.  
즉, 현재 노드의 모든 인접한 노드들을 우선적으로 탐색하고, 그 다음 단계의 인접한 노드들을 탐색하는 방식이다.   
이러한 방식으로 그래프의 너비를 우선적으로 탐색하기 떄문에 "너비 우선 탐색"이라고 불린다.

BFS의 작동 과정은 다음과 같다:

1. 시작 노드를 방문하고, 방문한 노드를 방문한 노드 목록에 추가한다.
2. 시작 노드를 큐에 넣는다.
3. 큐가 빌 때까지 다음 작업을 반복한다:
    - 큐에서 하나의 노드를 꺼내고, 해당 노드와 연결된 모든 인접한 노드들을 검사한다.  
    - 아직 방문하지 않은 인접한 노드가 있으면, 해당 노드를 방문하고 방문한 노드 목록에 추가한 후 큐에 넣는다.
4. 위의 과정을 반복하여 큐가 빌 때까지 탐색한다.

BFS는 그래프의 모든 노드를 방문하는데 사용될 수 있으며, 너비 우선 탐색을 통해 최단 경로를 찾는 문제에 유용하다.   
또한 BFS는 그래프의 연결 요소를 찾거나, 그래프의 구조를 분석하거나, 그래프 기반의 문제를 해결하는 데에도 활용될 수 있다.

### 장단점
장점:
1. 최단 경로를 보장: BFS는 너비 우선으로 탐색하기 때문에, 시작 노드에서 다른 모든 노드까지의 최단 경로를 보장한다.
2. 무한 루프에 빠지지 않음: BFS는 그래프에서 싸이클이 있어도 무한 루프에 빠지지 않는다.   
따라서, 방문한 노드를 확인할 필요가 없다.
3. 구조 분석에 유리: BFS는 그래프의 구조를 분석하는 데에 유용하다.  
그래프의 깊이를 계산하거나, 그래프의 계층 구조를 파악하는 등의 작업에 활용될 수 있다.

단점:
1. 메모리 요구량이 큼: BFS는 큐를 사용하여 탐색 경로를 저장해야 하므로, 메모리 요구량이 상대적으로 크다.  
그래프의 크기가 큰 경우, 메모리 부족 문제가 발생할 수 있다.
2. 시간복잡도가 큼: 그래프가 크고 밀집된 경우, 모든 노드의 간선을 탐색해야 하므로 시간복잡도가 크게 증가할 수 있다.

BFS는 최단 경로를 찾는 문제에 유용하며, 그래프의 구조를 분석하는데에도 유리한 알고리즘이다.   
하지만 메모리 요구량과 시간복잡도를 고려해야 한다는 점을 명심해야 한다.

### 구현
[그래프 구현 코드](https://github.com/corn1200/Data-structure-docs/blob/main/sample_code/Graph.cs)

```c#
public static class BFS<T>
{
  // ...
}
```
BFS 클래스를 작성한다.  

```c#
public static void Search(Node<T> start)
{
  Queue<Node<T>> queue = new Queue<Node<T>>();
  queue.Enqueue(start);

  while (queue.Count > 0)
  {
    Node<T> current = queue.Dequeue();
    Console.Write(current.Data + " ");

    foreach (Node<T> item in current.Neighbors)
    {
      queue.Enqueue(item);
    }
  }
}
```
BFS 탐색 메서드를 작성한다.   
방문할 노드를 저장하는 큐를 선언하고 큐에 시작 노드를 삽입한다.  
방문할 노드가 없을 때까지 아래 동작을 반복한다.
1. 큐에서 노드를 제거하고 변수에 저장한다.
2. 방문한 노드를 출력한다.
3. 방문한 노드의 이웃 노드들을 전부 큐에 삽입한다.

[파일](/sample_code/BFS.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
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
```
</details>

# 2.3. 다익스트라 알고리즘
다익스트라 알고리즘(Dijkstra's Algorithm)은 하나의 시작 노드로부터 다른 모든 노드까지의 최단 경로를 찾는 알고리즘이다.  
다익스트라 알고리즘은 가중치가 있는 그래프에서 작동하며, 음수 가중치가 없는 경우에 사용된다.  

다익스트라 알고리즘의 작동 과정은 다음과 같다.

1. 시작 노드를 선택하고, 시작 노드로부터의 거리를 0으로 초기화하고 나머지 노드들의 거리를 무한대(infinity)로 설정한다.
2. 아직 방문하지 않은 노드 중에서 거리가 가장 짧은 노드를 선택한다.   
이를 "현재 노드"라고 칭한다.
3. 현재 노드와 연결된 모든 인접한 노드들을 검사한다.
4. 인접한 노드들의 거리를 갱신한다.   
현재 노드를 거쳐서 인접한 노드로 가는 거리가 더 짧은 경우에는 해당 거리로 업데이트한다.
5. 모든 인접한 노드들에 대해 거리 갱신이 완료되면, 현재 노드를 방문한 것으로 표시한다.
6. 모든 노드를 방문할 때까지 2-5 단계를 반복한다.

다익스트라 알고리즘은 그래프의 모든 노드를 탐색하며, 시작 노드로부터의 최단 거리를 계산하는 방식으로 작동한다.  
각 노드에 대해 최단 거리를 업데이트하면서 진행하므로, 최종적으로 모든 노드까지의 최단 거리가 계산된다.