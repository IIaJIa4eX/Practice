using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Coursework
{
    /*
     * Класс для для отображения данных на консоле
     */
    public static class UIDraw
    {

        public static void ClearConsole()
        {

            Console.Clear();

        }


        public static void DrawCatFilesPage(int currentPage, int maxPage, string[] ents, string currentPath)
        {
            ClearConsole();
            Console.WriteLine($"Каталог: {currentPath}");
            Console.WriteLine($"Страница номер {currentPage} из {maxPage}");
            Console.WriteLine("___________________________________________");

            for (int i = 0; i < ents.Length; i++)
            {
                try
                {
                    Console.WriteLine(ents[i]);
                }
                catch
                {
                    Console.WriteLine("При отображении файла что-то пошло не так");
                }
            }

            Console.WriteLine("___________________________________________");
            Console.WriteLine("Используйте стрелки <- ->, чтобы полистать страницы.");
            Console.WriteLine("Если хотите выйти из режима просмотра и вписать команду, нажмите 'Esc' ");

        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowHelp()
        {
            Console.WriteLine("Чтобы скопировать файл введите >cpf<[полный путь к файлу]<[куда скопировать, с каким именем]");
            Console.WriteLine("Чтобы удалить файл введите >dlf<[полный путь к файлу]");
            Console.WriteLine("Чтобы скопировать папку введите >cpd<[полный путь к папке]<[куда скопировать, в какую папку, с каким именем]");
            Console.WriteLine("Чтобы удалить папку введите >dld<[полный путь к папке]");
            Console.WriteLine("Чтобы получить информацию о файле введите >gfi<[полный путь к файлу]");
            Console.WriteLine("Чтобы получить информацию о директории введите >gdi<[полный путь к директории]");
            Console.WriteLine("Чтобы получить информацию о директории и посмотреть файлы в ней, введите >showfullinf<[полный путь к директории]");
            Console.WriteLine("Для выхода, введите >exit");
            Console.WriteLine(@"Все пути вводятся в формате  C:\Folder1\Folder2\File.rsl. Вместо пробелов -  указатель '<'!");
            Console.WriteLine("При работе с файлами нужно указывать их тип! txt, png  и тд");


        }

    }
}
