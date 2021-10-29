using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Coursework
{
    public static class FileCatManipulation
    {
        public static void CopyFile(string sourcePath, string destinationPath)
        {

            if (File.Exists(sourcePath) && Directory.Exists(destinationPath))
            {
                try
                {
                    ManipulationLogic.CopyFileLogic(sourcePath, destinationPath);
                    UIDraw.WriteMessage("Копирование файла завершено успешно!");
                }
                catch
                {
                    UIDraw.WriteMessage("При копировании файла что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Не удалось найти указанный файл, либо, папку назначения");
            }

        }

        public static void CopyFolder(string sourcePath, string destinationPath)
        {

            if (Directory.Exists(sourcePath))
            {
                try
                {
                    ManipulationLogic.CopyFolderLogic(sourcePath, destinationPath);
                    UIDraw.WriteMessage("Копирование папки завершено успешно!");
                }
                catch (Exception ex)
                {
                    UIDraw.WriteMessage("При копировании папки что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Указанная папка для копирования не существует");
            }

        }

        public static void DeleteFolder(string folderPath)
        {

            if (Directory.Exists(folderPath))
            {
                try
                {
                    ManipulationLogic.DeleteFolderLogic(folderPath);
                    UIDraw.WriteMessage("Удаление папки завершено успешно!");
                }
                catch (Exception ex)
                {
                    UIDraw.WriteMessage("При удалении папки что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Указанная папка для удаления не найдена");
            }

        }




        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    ManipulationLogic.DeleteFileLogic(filePath);
                    UIDraw.WriteMessage("Удаление файла заверешено успешно!");

                }
                catch (Exception ex)
                {
                    UIDraw.WriteMessage("При удаление файла что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Такого файла не существует");
            }
        }

    }
}
