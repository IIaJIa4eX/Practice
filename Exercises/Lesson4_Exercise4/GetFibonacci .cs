using System;

namespace Fibonacci
{
    class Program
    {

        public static long Fibo(long number)
        {
          

            if(number == 0)
            {
                return 0;
            }

            if(number == 1)
            {
                return 1;
            }

            return Fibo(number - 1) + Fibo(number-2);
        }




        static void Main(string[] args)
        {


            Console.WriteLine(Fibo(19));


        }
    }
}

