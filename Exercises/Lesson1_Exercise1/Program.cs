using System;

namespace HelloUser
{
    class Program
    {
        /*С заданием справился без каких-либо трудностей.
         *Трудности возникли с GIT, Долго не мог понять как сделать pull-request
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
