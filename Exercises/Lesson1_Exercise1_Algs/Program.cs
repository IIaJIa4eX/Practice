using System;

namespace Lesson1_Exercise1_Algs
{
    class Program
    {


        public class ForTesting
        {
            public int inParam { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }

        }


        public static string Function(int number)
        {
            int d = 0, i = 2;
            string res;

            if(number < 0)
            {
                throw new ArgumentException("paramenter must be positive");

            }


            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }
                if(number % i != 0)
                {
                    i++;
                }
            }

            if (d == 0)
            {
                
                    res = "Простое";               
            }
            else
            {
                if (number == 4 || number == 8)
                {
                    res = "Простое";
                }
                else
                {
                    res = "Не простое";
                }
            }


            return res;
        }

        static void CheckIsValid(ForTesting testCase)
        {

            try
            {
                var actual = Function(testCase.inParam);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch(ArgumentException e)
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

            var test1 = new ForTesting { inParam = 1, Expected = "Простое" };
            var test2 = new ForTesting { inParam = 2, Expected = "Простое" };
            var test3 = new ForTesting { inParam = 3, Expected = "Простое" };
            var test4 = new ForTesting { inParam = 4, Expected = "Не простое" };
            var test5 = new ForTesting { inParam = 8, Expected = "Не простое" };
            var test6 = new ForTesting { inParam = -1, Expected = "Простое" };

            CheckIsValid(test1);
            CheckIsValid(test2);
            CheckIsValid(test3);
            CheckIsValid(test4);
            CheckIsValid(test5);
            CheckIsValid(test6);

        }




    }
}
