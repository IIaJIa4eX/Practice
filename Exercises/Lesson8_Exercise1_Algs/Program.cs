using System;
using System.Collections.Generic;

namespace Lesson8_Exercise1_Algs
{
    class Program
    {

        static int[] BucketSort(int[] arr, int bucCount)
        {

            if(arr.Length <= 1)
            {
                return arr;
            }

            List<int>[] buckets = new List<int>[bucCount];

            for (int i = 0; i < bucCount; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < arr.Length; i++) 
            {

                if(arr[i] < 50) //придумал простое условие(что первое на ум пришло)
                {
                    buckets[0].Add(arr[i]);
                }
                else
                {
                    buckets[1].Add(arr[i]);
                }
                
            }

            for (int j = 0; j < bucCount; j++)
            {
                InsertionSort(buckets[j]);
               //buckets[j].Sort();
            }
            int index = 0;
            for (int i = 0; i < bucCount; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[index] = buckets[i][j];
                    index++;
                }
            }

            return arr;
        }


        public static void InsertionSort(List<int> arr)
        {
            int tmp;
        
            for (int i = 0; i < arr.Count - 1; i++)
            {


                if (arr[i + 1] < arr[i])
                {
                    tmp = arr[i + 1];
                    int current = i;

                    while (tmp < arr[current])
                    {
                        arr[current + 1] = arr[current];
                        arr[current] = tmp;

                        if (current != 0)
                        {
                            current--;
                        }
                    }

                }
            }
        }


        public static void Main()
        {
            int[] arr = { 1, 4, 8, 23, 56, 53, 78, 72, 44, 39, 99, 86, 12, 15};

            int bucketsCount = 2;


            var arr1 = BucketSort(arr, bucketsCount);

            Console.WriteLine("Сортированный массив");

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write($"{arr1[i]} ");
            }
        }
    }

}
