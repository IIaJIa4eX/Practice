using System;

namespace Exercise1
{
    class Program
    {
        //С заданием справился без каких-либо трудностей.

        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста, укажите своё имя");

            string userName = Console.ReadLine();

            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Today}");

            Console.ReadLine();
        }
    }
}
