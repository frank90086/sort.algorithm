using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Sort.Algorithm;

public class Algorithm
{
    private readonly int[] data;

    public Algorithm()
    {
        data = new int[1000000];
        var random = new Random();
        for (int i = 0; i < 1000000; i++)
        {
            data[i] = random.Next(0, 1000000);
        }
    }

    public IEnumerable<int[]> Datas(){
        yield return data[0..10];
        yield return data[0..100];
        yield return data[0..1000];
        yield return data[0..10000];
        yield return data[0..100000];
    }

    [Benchmark]
    [ArgumentsSource(nameof(Datas))]
    public void Selection(int[] input)
    {
        var list = input;

        for (int i = 0; i < list.Length; i++)
        {
            var min = i;
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[min] > list[j])
                    min = j;
            }

            list = Swap(list, min, i);
        }

        int[] Swap(int[] list, int i, int j)
        {
            if (i == j) return list;

            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;

            return list;
        }
    }

    [Benchmark]
    [ArgumentsSource(nameof(Datas))]
    public void Insertion(int[] input)
    {
        var list = input;

        for (int i = 1; i < list.Length; i++)
        {
            var j = i;
            while (j > 0 && list[j] < list[j - 1])
            {
                var temp = list[j - 1];
                list[j - 1] = list[j];
                list[j] = temp;
                j -= 1;
            }
        }
    }

    // [Benchmark]
    [ArgumentsSource(nameof(Datas))]
    public void MergeByList(int[] input)
    {
        var result = mergeAndSort(input);

        int[] mergeAndSort(int[] array)
        {
            if (array.Length > 1)
            {
                var mid = array.Length / 2;

                var leftArray = mergeAndSort(array[0..mid]);
                var rightArray = mergeAndSort(array[mid..array.Length]);

                var result = new List<int>();
                int tempLeftIndex = 0, tempRightIndex = 0;
                foreach (var (leftValue, leftIndex) in leftArray.Select((v, i) => (v, i)))
                {
                    foreach (var (rightValue, rightIndex) in rightArray.Select((v, i) => (v, i)))
                    {
                        if (leftValue <= rightValue)
                        {
                            if (tempLeftIndex <= leftIndex)
                            {
                                result.Add(leftValue);
                                tempLeftIndex += 1;
                            }
                        }
                        else
                        {
                            if (tempRightIndex <= rightIndex)
                            {
                                result.Add(rightValue);
                                tempRightIndex += 1;
                            }
                        }
                    }
                }

                if (tempLeftIndex < leftArray.Length)
                    result.AddRange(leftArray[tempLeftIndex..leftArray.Length]);
                if (tempRightIndex < rightArray.Length)
                    result.AddRange(rightArray[tempRightIndex..rightArray.Length]);

                return result.ToArray();
            }

            return array;
        }
    }

    [Benchmark]
    [ArgumentsSource(nameof(Datas))]
    public void MergeByArray(int[] input)
    {
        var result = mergeAndSort(input);

        int[] mergeAndSort(int[] array)
        {
            if (array.Length > 1)
            {
                var mid = array.Length / 2;

                var leftArray = mergeAndSort(array[0..mid]);
                var rightArray = mergeAndSort(array[mid..array.Length]);

                var result = new int[array.Length];
                int resultIndex = 0, tempLeftIndex = 0, tempRightIndex = 0;

                for (int leftIndex = 0; leftIndex < leftArray.Length; leftIndex++)
                {
                    for (int rightIndex = 0; rightIndex < rightArray.Length; rightIndex++)
                    {
                        if (leftArray[leftIndex] <= rightArray[rightIndex])
                        {
                            if (tempLeftIndex <= leftIndex)
                            {
                                result[resultIndex] = leftArray[leftIndex];
                                resultIndex += 1;
                                tempLeftIndex += 1;
                            }
                        }
                        else
                        {
                            if (tempRightIndex <= rightIndex)
                            {
                                result[resultIndex] = rightArray[rightIndex];
                                resultIndex += 1;
                                tempRightIndex += 1;
                            }
                        }
                    }
                }

                if (tempLeftIndex < leftArray.Length)
                {
                    foreach (var remainedLeft in leftArray[tempLeftIndex..leftArray.Length])
                    {
                        result[resultIndex] = remainedLeft;
                        resultIndex += 1;
                    }
                }

                if (tempRightIndex < rightArray.Length)
                {
                    foreach (var remainedRight in rightArray[tempRightIndex..rightArray.Length])
                    {
                        result[resultIndex] = remainedRight;
                        resultIndex += 1;
                    }
                }

                return result.ToArray();
            }

            return array;
        }
    }
}