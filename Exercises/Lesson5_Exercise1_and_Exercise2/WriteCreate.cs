using System;
using System.IO;

namespace Lesson5_Exercise1_and_Exercise2
{
    class WriteCreate
    {
        static void Main(string[] args)
        {
            string fileName = "Startup.txt";

            string path = $@"C:\Users\{Environment.UserName}\Desktop\{fileName}";

            File.AppendAllText(path, $"Последний раз программа была заущена в: {DateTime.Now} {Environment.NewLine}");

            Console.WriteLine("Введите текст, для записи в файл:");

            var input = Console.ReadLine();

            File.AppendAllText(path, $"{input} {Environment.NewLine}");

        }
    }
}

