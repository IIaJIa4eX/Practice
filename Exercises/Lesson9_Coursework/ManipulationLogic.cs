using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Coursework
{
    class ManipulationLogic
    {
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
                }
                else
                {
                    try
                    {
                        Directory.Delete(files[i]);

                    }
                    catch
                    {
                        new DirectoryInfo(files[i]).Attributes = FileAttributes.Normal;
                        Directory.Delete(files[i]);
                    }

                }
            }

            new DirectoryInfo(folderPath).Attributes = FileAttributes.Normal;
            Directory.Delete(folderPath);
        }

        public static void CopyFileLogic(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }


        public static void DeleteFileLogic(string filePath)
        {

            File.Delete(filePath);
        }

        public static (string[] filesArr, int lastIndex) GetFileCatPageLeft(string[] files, bool isFirstPage, int lastIndex, int itemsNumber = 20)
        {
            var tempArr = new string[itemsNumber];

            int last;

            int lowerbound = (lastIndex - itemsNumber) < files.GetLowerBound(0) ? 0 : lastIndex - itemsNumber;
            int upperBound = lowerbound + itemsNumber > files.GetUpperBound(0) ? files.GetUpperBound(0) : itemsNumber;

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

            if ((lastIndex - itemsNumber) < files.GetLowerBound(0))
            {
                last = lastIndex;
            }
            else
            {
                last = lastIndex - (itemsNumber - 1);
            }

            return (tempArr, last);


        }


        

        public static (string[] filesArr, int lastIndex) GetFileCatPageRight(string[] files, bool isFirstPage, int lastIndex, int itemsNumber = 20)
        {

            var tempArr = new string[itemsNumber];

            int last;

            int upperBound = ((lastIndex + 1) + itemsNumber) > files.GetUpperBound(0) ? itemsNumber - (((lastIndex) + itemsNumber) - files.GetUpperBound(0)) : itemsNumber;
        
            if (!isFirstPage)
            {
                for (int i = lastIndex + 1, y = 0, counter = 0; counter <= upperBound - 1; i++, y++, counter++)
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
            else
            {
                for (int i = lastIndex, y = 0, counter = 0; counter <= upperBound - 1; i++, y++,counter++)
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


            if (((lastIndex + 1) + itemsNumber) > files.GetUpperBound(0))
            {
                last = lastIndex;
            }
            else
            {
                last = lastIndex + (itemsNumber - 1);
            }

            return (tempArr, last);

        }

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
