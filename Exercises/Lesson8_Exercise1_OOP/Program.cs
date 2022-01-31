using System;
using System.IO;

namespace Lesson8_Exercise1_OOP
{
    sealed class  Program
    {
        static void Main(string[] args)
        {
            CommandLineParser commandParser = new CommandLineParser();
            bool isworking = true;
            Console.WriteLine("здравствуйте, вы используете файловый менеджер!");
            Console.WriteLine(@"чтобы узнать, какие команды доступны - нажмите '>help' ");
            

            while (isworking)
            {
                isworking = commandParser.CommandHandler(Console.ReadLine());
            }




        }
    }
}
