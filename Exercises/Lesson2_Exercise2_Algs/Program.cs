using System;

namespace Lesson2_Exercise2_Algs
{
    class Program //Сложность алгоритма бинарноо поиска.   O(log n)
    {

        public class ForTesting
        {
            public int[] inArr { get; set; }
            public int Expected { get; set; }
            public int searchedValue { get; set; }

        }



        static void CheckIsValid(ForTesting testCase)
        {

            try
            {
                var actual = BinarySearch(testCase.inArr, testCase.searchedValue);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"INVALID TEST {e.Message}");
            }
            catch
            {
                Console.WriteLine("INVALID TEST Something goes wrong");
            }

        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {

            if (searchValue < 0)
            {
                throw new ArgumentException("paramenter must be positive");
            }

            if (searchValue > inputArray.Length -1 )
            {
                throw new ArgumentException("paramenter out of an Array range");
            }

            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)  // Сложность O(log n)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        static void Main(string[] args)
        {
            var ss = new int[1001];

            for(int i = 1; i < ss.Length; i++)
            {
                ss[i] = i;
            }

            var test1 = new ForTesting {inArr = ss, searchedValue = 1000, Expected = 1000 };
            var test2 = new ForTesting { inArr = ss, searchedValue = 65, Expected = 65 };
            var test3 = new ForTesting { inArr = ss, searchedValue = 391, Expected = 391 };
            var test4 = new ForTesting { inArr = ss, searchedValue = 1001, Expected = 1001 };
            var test5 = new ForTesting { inArr = ss, searchedValue = -1, Expected = -1 };
            CheckIsValid(test1);
            CheckIsValid(test2);
            CheckIsValid(test3);
            CheckIsValid(test4);
            CheckIsValid(test5);

            Console.WriteLine(BinarySearch(ss,1000));

        }
    }
}
