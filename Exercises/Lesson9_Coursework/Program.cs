using System;
using System.IO;

namespace Lesson9_Coursework
{



    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Console.WriteLine("Здравствуйте, Вы используете файловый менеджер!");           
            Console.WriteLine(@"Чтобы узнать, какие команды доступны - нажмите '>help' ");


            while (isWorking)
            {
                isWorking = CommandLineParser.CommandHandler(Console.ReadLine());
            }

        }
    }

}
