using System;

namespace FIOinterpolation
{
    class GetName
    {

        static public string GetFullName(string firstName, string lastName, string patronymic)
        {

          return $"{firstName} {lastName} {patronymic}";

        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Ivanov", "Ivan", "Ivanovitch"));
            Console.WriteLine(GetFullName("Petrov", "Petr", "Petrovich"));
            Console.WriteLine(GetFullName("Antonov", "Anton", "Antonovich"));
            Console.WriteLine(GetFullName("Sergeev", "Sergey", "Sergeevich"));
            Console.WriteLine(GetFullName("Alexeyev", "Alexey", "Alexeevich"));

        }
    }
}
