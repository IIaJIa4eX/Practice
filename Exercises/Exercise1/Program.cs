using System;

namespace Exercise1
{
    class Program
    {
        /*С заданием справился без каких-либо трудностей.
         *Трудности возникли с GIT, Долго не могк понять как сделать pull-request
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста, укажите своё имя");

            string userName = Console.ReadLine();

            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Today}");

            Console.ReadLine();
        }
    }
}
