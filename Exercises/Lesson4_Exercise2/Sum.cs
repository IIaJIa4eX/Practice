using System;

namespace NumbersSum
{
    class Sum
    {


        static void GetSum(string numbers)
        {
            var tmp = numbers.Split(" ");
            var sum = 0;

            for(var i = 0; i <= tmp.GetUpperBound(0); i++)
            {
                sum += Convert.ToInt32(tmp[i]);
            }

            Console.WriteLine($"Сумма числел равна: {sum}");
        }


        static void Main(string[] args)
        {
            GetSum(Console.ReadLine());
        }


    }
}
