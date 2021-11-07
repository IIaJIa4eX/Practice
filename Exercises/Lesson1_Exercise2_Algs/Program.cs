using System;

namespace Lesson1_Exercise2_Algs
{
    class Program
    {
        // O(N^3). - n в кубе, думаю.
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++) // O(N)

            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)

                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)

                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
        }
    }
}
