using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[10]
            {
                1,
                3,
                2,
                6,
                4,
                7,
                5,
                9,
                2,
                5,
            };

            {
                int[] bubbleSorted = (int[])data.Clone();
                DateTime before = DateTime.Now;
                BubbleSort(bubbleSorted);
                Console.WriteLine($"bubble {(DateTime.Now - before).TotalMilliseconds:0.00}ms");
                foreach (var item in bubbleSorted)
                {
                    Console.WriteLine(item);
                }
            }

            {
                List<int> insertionSorted = ((int[])data.Clone()).ToList();
                DateTime before = DateTime.Now;
                InsertionSort(insertionSorted);
                Console.WriteLine($"insertion {(DateTime.Now - before).TotalMilliseconds:0.00}ms");
                foreach (var item in insertionSorted)
                {
                    Console.WriteLine(item);
                }
            }

            {
                int[] mergeSorted = (int[])data.Clone();
                DateTime before = DateTime.Now;
                MergeSort(ref mergeSorted);
                Console.WriteLine($"merge {(DateTime.Now - before).TotalMilliseconds:0.00}ms");
                foreach (var item in mergeSorted)
                {
                    Console.WriteLine(item);
                }
            }

            {
                int[] quickSorted = (int[])data.Clone();
                DateTime before = DateTime.Now;
                QuickSort(quickSorted);
                Console.WriteLine($"quick {(DateTime.Now - before).TotalMilliseconds:0.00}ms");
                foreach (var item in quickSorted)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void QuickSort(int[] arr) => QuickSort(arr, 0, arr.Length);

        static void QuickSort(int[] arr, int start, int end)
        {
            if (end - start > 0)
            {
                int num = arr[end - 1];
                int pivot = start;

                for (int j = start; j < end - 1; j++)
                {
                    if (arr[j] < num)
                    {

                        int temp = arr[j];
                        arr[j] = arr[pivot];
                        arr[pivot] = temp;

                        pivot += 1;
                    }
                }

                int temp2 = arr[pivot];
                arr[pivot] = arr[end - 1];
                arr[end - 1] = temp2;

                QuickSort(arr, start, pivot);
                QuickSort(arr, pivot + 1, end);
            }
        }

        static void MergeSort(ref int[] data) => data = MergeSort(data, 0, data.Length);

        static int[] MergeSort(int[] data, int start, int end)
        {
            int length = end - start;
            if (length == 0 || length == 1)
            {
                return new int[] { };
            } else if (length == 2)
            {
                if (data[end - 1] < data[start])
                {
                    return new int[] { data[end - 1], data[start] };
                } else
                {
                    return new int[] { data[start], data[end - 1] };
                }
            }
            int[] first;
            int[] second;
            if (length % 2 == 0) // can divide length by 2
            {
                first = MergeSort(data, start + (length / 2), end);
                second = MergeSort(data, start, end - (length / 2));
            } else
            {
                first = MergeSort(data, start + (length / 2) + 1, end); // we need to add 1 to the start or else it will overlap with the end of the next one
                second = MergeSort(data, start, end - (length / 2));
                
            }

            int[] buffer = new int[first.Length + second.Length];
            int bufferIndex = 0;
            int firstIndex = 0;
            int secondIndex = 0;
            while (firstIndex < first.Length || secondIndex < second.Length)
            {
                int num;
                if (firstIndex < first.Length)
                {
                    num = first[firstIndex];
                }
                else
                {
                    num = int.MaxValue;
                }

                if (secondIndex < second.Length && second[secondIndex] < num)
                {
                    buffer[bufferIndex] = second[secondIndex];
                    secondIndex++;
                } else
                {
                    buffer[bufferIndex] = num;
                    firstIndex++;
                }

                bufferIndex++;
            }

            return buffer;
        }

        static void InsertionSort(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] < data[i - 1]) {
                    for (int j = i; j >= 1; j--)
                    {
                        if (data[j - 1] < data[i])
                        {
                            int temp = data[i];
                            data.RemoveAt(i);
                            data.Insert(j, temp);

                            break;
                        }
                    }
                }
            }
        }

        static void BubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - 1; j++)
                {
                    if (data[j + 1] < data[j])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
    }
}
