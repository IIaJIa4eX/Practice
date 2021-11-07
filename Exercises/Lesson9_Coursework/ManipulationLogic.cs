using System;
using System.IO;

namespace Lesson9_Coursework
{


    /*
     * Класс для логической работы с данными
     * Под каждый запрос пользователя этот класс имеет отдельный метод, который передает данные для логической обработки
     * классу ManipulationLogic, а затем, передаёт обработанные данные классу UIDraw для отрисовки.
     * Также, в этом классе, отлавливаются ошибки.
     */
    class ManipulationLogic
    {
        /*
    * Метод CopyFolderLogic копирует папку.
    * После передачи пути, начинает пробигаться по папке, которую нужно скопировать.
    * Каждый подуровень начинается с поиска файлов. Если находит, копирует файлы в новую папку если нет, начинает искать папки.
    * Если папки есть, то создает папки в новой директори серкально с директорией-источником.
    */
        public static void CopyFolderLogic(string sourcePath, string destinationPath)
        {

            var dir = Directory.CreateDirectory(destinationPath);

            var folders = Directory.GetDirectories(sourcePath);
            var files = Directory.GetFiles(sourcePath);

            if (files.Length > 0)
            {

                foreach (var file in files)
                {

                    File.Copy(file, Path.Combine(dir.FullName, Path.GetFileName(file)), true);

                }

            }

            if (folders.Length > 0)
            {
                foreach (var folder in folders)
                {

                    CopyFolderLogic(folder, Path.Combine(destinationPath, new DirectoryInfo(folder).Name));

                }
            }


        }

        /*
    * Метод DeleteFolderLogic удаляет папку.
    * После передачи пути и считывания всего содержимого в папке, начинает пробигаться по массиву и удалять файлы и папки.
    * Если удалять файл либо папку не получается, изменяет атрибут доступа на Normal, тогда файл либо папка может удалиться.
    * 
    */
        public static void DeleteFolderLogic(string folderPath)
        {
            var files = Directory.GetFileSystemEntries(folderPath, "*", SearchOption.AllDirectories);

            for (int i = files.GetUpperBound(0); i >= files.GetLowerBound(0); i--)
            {
                if (File.Exists(files[i]))
                {
                    try
                    {
                        File.Delete(files[i]);

                    }
                    catch (UnauthorizedAccessException)
                    {
                        File.SetAttributes(files[i], FileAttributes.Normal);
                        File.Delete(files[i]);
                    }
                    catch
                    {
                        UIDraw.WriteMessage($"При удалении файла {new FileInfo(files[i]).Name} что-то пошло не так");
                    }
                }
                else
                {
                    try
                    {
                        Directory.Delete(files[i]);

                    }
                    catch
                    {
                        if (Directory.Exists(files[i]))
                        {
                            new DirectoryInfo(files[i]).Attributes = FileAttributes.Normal;
                            Directory.Delete(files[i]);
                        }
                        else
                        {
                            UIDraw.WriteMessage($"При удалении папки{new DirectoryInfo(files[i]).Name} что-то пошло не так");
                        }
                    }

                }
            }

            new DirectoryInfo(folderPath).Attributes = FileAttributes.Normal;
            Directory.Delete(folderPath);
        }


        //Коприует файл
        public static void CopyFileLogic(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }

        //Удаляет файл
        public static void DeleteFileLogic(string filePath)
        {

            File.Delete(filePath);
        }


        /*
        * Метод GetFileCatPageLeft перемещается по массиву айтемов влево.
        * Возвращает индекс, с которого надо начинать при следуюущем вызове метода GetFileCatPageLeft.
        * Также, возвращает индекс, с которго начинает передвигаться метод GetFileCatPageRight;
        * Уменьшает тек. номер страницы
        */

        public static (string[] filesArr, int nextLowerIndex, int nextUpperIndex, int currentPage)
        GetFileCatPageLeft(string[] files, bool isFirstPage, int currentIndex, int currentPage, int totalPages, int itemsNumber = 20)
        {
            var tempArr = new string[itemsNumber];

            int nextLower;
            int nextUpper;
            int curPage;

            int lowerbound = (currentIndex - itemsNumber) < files.GetLowerBound(0) ? 0 : currentIndex;
            int upperBound = lowerbound + itemsNumber > files.GetUpperBound(0) ? files.Length : itemsNumber;

            //Отображает элементы от текущего индекса
            if (!isFirstPage)
            {
                for (int i = lowerbound, y = 0, counter = 0; counter < upperBound; i++, y++, counter++)
                {
                    try
                    {
                        tempArr[y] = File.Exists(files[i]) ? $"{Path.GetFileName(files[i])} - Файл " : $"{new DirectoryInfo(files[i]).Name} - Папка";
                    }
                    catch
                    {
                        tempArr[y] = "не удалось получить информацию о элементе";
                    }

                }
            }

            //проверки на выход за границы. + уменьшение счётчика страниц + смещение индексов
            if (currentIndex - itemsNumber < 0)
            {
                if (currentPage == 1 && totalPages == 1)
                {
                    nextLower = currentIndex;
                    nextUpper = currentIndex;
                    curPage = currentPage;
                }
                else
                {
                    nextLower = currentIndex;
                    nextUpper = currentIndex + itemsNumber;
                    if (currentPage - 1 < 1)
                    {
                        curPage = currentPage;
                    }
                    else
                    {
                        curPage = currentPage - 1;
                    }
                }
            }
            else
            {
                nextLower = currentIndex - itemsNumber;
                nextUpper = currentIndex + itemsNumber;

                if (currentPage - 1 < 1)
                {
                    curPage = currentPage;
                }
                else
                {
                    curPage = currentPage - 1;
                }
            }

            return (tempArr, nextLower, nextUpper, curPage);


        }



        /*
        * Метод GetFileCatPageRight перемещается по массиву айтемов врпаво.
        * Возвращает индекс, с которого надо начинать при следуюущем вызове метода GetFileCatPageRight.
        * Также, возвращает индекс, с которго начинает передвигаться метод GetFileCatPageLeft;
        * Увеличивает тек. номер страницы
        */

        public static (string[] filesArr, int nextStartIndex, int prevIndex, int currentPage)
        GetFileCatPageRight(string[] files, bool isFirstPage, int lastIndex, int currentPage, int totalPages, int itemsNumber = 20)
        {

            var tempArr = new string[itemsNumber];
            int currentIndex = lastIndex;

            int nextStartIndex;
            int nexLowerIndex;
            int curPage;

            int upperBound = (currentIndex + itemsNumber) > files.GetUpperBound(0) ? itemsNumber - ((currentIndex + itemsNumber) - files.GetUpperBound(0) - 1 ) : itemsNumber;

            //Отображает элементы от текущего индекса
                for (int i = currentIndex, y = 0, counter = 0; counter <= upperBound - 1; i++, y++, counter++)
                {
                    try
                    {
                        tempArr[y] = File.Exists(files[i]) ? $"{Path.GetFileName(files[i])} - Файл " : $"{new DirectoryInfo(files[i]).Name} - Папка";
                    }
                    catch
                    {
                        tempArr[y] = "не удалось получить информацию о элементе";
                    }

                }

            //проверки на выход за границы. + увеличивание счётчика страниц + смещение индексов
            if (currentIndex + itemsNumber > files.GetUpperBound(0))
            {
                if (currentPage == 1 && totalPages == 1)
                {
                    nextStartIndex = currentIndex;
                    nexLowerIndex = currentIndex;
                    curPage = currentPage;
                }
                else
                {
                    nextStartIndex = lastIndex;
                    nexLowerIndex = currentIndex - itemsNumber;

                    if (currentPage + 1 > totalPages)
                    {
                        curPage = currentPage;
                    }
                    else
                    {
                        curPage = currentPage + 1;
                    }
                }
            }
            else
            {
                nextStartIndex = lastIndex + itemsNumber;
                nexLowerIndex = currentIndex - itemsNumber;
                if (currentPage + 1 > totalPages)
                {
                    curPage = currentPage;
                }
                else
                {
                    curPage = currentPage + 1;
                }

            }

            return (tempArr, nextStartIndex, nexLowerIndex, curPage);

        }

        //Получает информацию о папке, чтобы получить размер папки пробегает по всем файлам и считыает из размер, потом складывает.
        public static string GetDirInfo(string path)
        {
            long totalFolderSize = 0;
            var ents = Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories);

            for (int i = 0; i < ents.Length; i++)
            {
                if (File.Exists(ents[i]))
                {
                    totalFolderSize += new FileInfo(ents[i]).Length;
                }
            }
            var dir = new DirectoryInfo(path);
            string Attrs = dir.Attributes.ToString();
            string crTime = dir.CreationTime.ToString();



            return $"Общий размер папки: {totalFolderSize}   Атрибуты папки: {Attrs}   Время создания: {crTime}";
        }


        //Получает информацию о файле
        public static string GetFileInfo(string path)
        {
            var file = new FileInfo(path);
            var size = file.Length.ToString();
            var attrs = file.Attributes.ToString();
            var crtime = file.CreationTime.ToString();

            return $"Размер файла: {size} Атрибуты файла: {attrs} Время создания: {crtime}";

        }
        
        
    }
}
