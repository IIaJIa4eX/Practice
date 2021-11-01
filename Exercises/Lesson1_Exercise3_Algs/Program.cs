using System;

namespace Lesson1_Exercise3_Algs
{
    class Program
    {


        public class ForTesting
        {
            public int inParam { get; set; }
            public long Expected { get; set; }
            public Exception ExpectedException { get; set; }

        }


        public static long FiboR(long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("paramenter must be positive");

            }

            if (number == 0)
            {
                return 0;
            }

            if (number == 1)
            {
                return 1;
            }

            return FiboR(number - 1) + FiboR(number - 2);
        }

        public static long FiboNoR(long number)
        {

            if(number == 0)
            {
                return 0;
            }

            if(number == 1)
            {
                return 1;
            }


            if (number < 0)
            {
                throw new ArgumentException("paramenter must be positive");

            }

            int fib1 = 1;
            int fib2 = 1;

            int i = 0;
            while (i < (number - 2))
            {
                var fib_sum = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib_sum;
                i = i + 1;
            }

            return fib2;
        }

        static void CheckIsValidRec(ForTesting testCase)
        {

            try
            {
                var actual = FiboR(testCase.inParam);

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

        static void CheckIsValidNoR(ForTesting testCase)
        {

            try
            {
                var actual = FiboNoR(testCase.inParam);

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




        static void Main(string[] args)
        {
            var test1 = new ForTesting { inParam = 1, Expected =  1};
            var test2 = new ForTesting { inParam = 2, Expected =  1}; 
            var test3 = new ForTesting { inParam = 3, Expected =  2};
            var test4 = new ForTesting { inParam = 4, Expected = 3 };
            var test5 = new ForTesting { inParam = 5, Expected =  8};//Fake
            var test6 = new ForTesting { inParam = -1, Expected = 1};

            CheckIsValidRec(test1);
            CheckIsValidRec(test2);
            CheckIsValidRec(test3);
            CheckIsValidRec(test4);
            CheckIsValidRec(test5);
            CheckIsValidRec(test6);

            CheckIsValidNoR(test1);
            CheckIsValidNoR(test2);
            CheckIsValidNoR(test3);
            CheckIsValidNoR(test4);
            CheckIsValidNoR(test5);
            CheckIsValidNoR(test6);
        }
    }
}
