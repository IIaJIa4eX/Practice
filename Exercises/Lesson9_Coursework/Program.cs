using System;
using System.IO;

namespace Lesson9_Coursework
{



    class Program
    {
        static void Main(string[] args)
        {

            bool working = true;

            Console.WriteLine("Здравсвуйте, Вы используете файловый менеджер!");
            Console.WriteLine(@"Чтобы узнать, какие команды доступны - нажмите '>help' ");

            var ents = Directory.GetFileSystemEntries(@"C:\Users\avborisov\Desktop\chek", "*", SearchOption.TopDirectoryOnly);
            int lastIndex = 0;

            var c = ManipulationLogic.GetFileCatPageRight(ents, true, 0);
            lastIndex = c.lastIndex;
            for (int i = 0; i < c.filesArr.Length; i++)
            {
                Console.WriteLine($"{i}_{c.filesArr[i]}");
            }
            while (true)
            {
                var a = Console.ReadKey();
                if (a.Key.ToString() == "RightArrow")
                {
                    Console.Clear();
                    var b = ManipulationLogic.GetFileCatPageRight(ents, false, lastIndex);
                    lastIndex = b.lastIndex;
                    for (int i = 0; i < b.filesArr.Length; i++)
                    {
                        Console.WriteLine($"{i}_{b.filesArr[i]}");
                    }
                }
                if (a.Key.ToString() == "LeftArrow")
                {
                    Console.Clear();
                    var b = ManipulationLogic.GetFileCatPageLeft(ents, false, lastIndex);
                    lastIndex = b.lastIndex;
                    for (int i = 0; i < b.filesArr.Length; i++)
                    {
                        Console.WriteLine($"{i}_{b.filesArr[i]}");
                    }
                }


            }

        }
    }

}
