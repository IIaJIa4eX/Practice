using System;

namespace OddOrEvenNumber
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число и узнайте, чётное оно или нет:");
            long number = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(number % 2 == 0 ? "Ваше число чётное" : "Ваше число нечётное");
            Console.ReadLine();

        }
    }
}
