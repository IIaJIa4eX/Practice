using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Exercise1_OOP
{
    public sealed class FileCatManipulation : ManipulationLogic
    {
        LogicWrapper logicWrapper;

        public FileCatManipulation()
        {

           logicWrapper = new();
        }

        
        public void CopyFile(string sourcePath, string destinationPath)
        {
            
            
            if (File.Exists(sourcePath))
            {
                try
                {
                    logicWrapper.CopyFileLogic(sourcePath, destinationPath);
                    UIDraw.WriteMessage("Копирование файла завершено успешно!");
                }
                catch (Exception e)
                {
                    UIDraw.WriteMessage("При копировании файла что-то пошло не так");
                    UIDraw.WriteMessage(e.Message);
                }
            }
            else
            {
                UIDraw.WriteMessage("Не удалось найти указанный файл");
            }

        }
        
        public void CopyFolder(string sourcePath, string destinationPath)
        {

            if (Directory.Exists(sourcePath))
            {
                try
                {
                    logicWrapper.CopyFolderLogic(sourcePath, destinationPath);
                    UIDraw.WriteMessage("Копирование папки завершено успешно!");
                }
                catch
                {
                    UIDraw.WriteMessage("При копировании папки что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Указанная папка для копирования не существует");
            }

        }

        public void DeleteFolder(string folderPath)
        {

            if (Directory.Exists(folderPath))
            {
                try
                {
                    logicWrapper.DeleteFolderLogic(folderPath);
                    UIDraw.WriteMessage("Удаление папки завершено успешно!");
                }
                catch
                {
                    UIDraw.WriteMessage("При удалении папки что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Указанная папка для удаления не найдена");
            }

        }




        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    logicWrapper.DeleteFileLogic(filePath);
                    UIDraw.WriteMessage("Удаление файла заверешено успешно!");

                }
                catch
                {
                    UIDraw.WriteMessage("При удаление файла что-то пошло не так");
                }
            }
            else
            {
                UIDraw.WriteMessage("Такого файла не существует");
            }
        }

        public string GetDirectoryInfo(string path)
        {
            string info;
            if (Directory.Exists(path))
            {
                try
                {
                    info = logicWrapper.GetDirInfo(path);

                }
                catch
                {
                    info = "Не удалось получить информацию о папке";
                }
            }
            else
            {
                info = ("Такой папки не существует");
            }

            return info;
        }

        public string GetFileFullInfo(string path)
        {
            string info;
            if (File.Exists(path))
            {
                try
                {
                    info = logicWrapper.GetFileInfo(path);

                }
                catch
                {
                    info = "Не удалось получить информацию о файле";
                }
            }
            else
            {
                info = "Такого файла не существует";
            }

            return info;
        }

        public void ShowFullInformation(string path)
        {

            UserSettings.UserConsole();

            if (Directory.Exists(path))
            {
                try
                {
                    bool working = true;
                    var ents = Directory.GetFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);
                    int nextUpperIndex = 0;
                    int nextLowerIndex = 0;
                    int pageItems = 20;
                    try
                    {
                        pageItems = Convert.ToInt32(UserSettings.ReadSetting("ElemCount"));
                    }
                    catch
                    {

                    }
                    int currentPage = 1;

                    decimal totalpages = Math.Ceiling(Convert.ToDecimal(ents.Length) / Convert.ToDecimal(pageItems));
                    int total = Convert.ToInt32(totalpages);

                    var c = LogicWrapper.GetFileCatPageRight(ents, true, nextUpperIndex, currentPage, total, pageItems);
                    nextUpperIndex = c.nextStartIndex;

                    UIDraw.DrawCatFilesPage(currentPage, total, c.filesArr, path);
                    while (working)
                    {
                        var a = Console.ReadKey();
                        if (a.Key.ToString() == "RightArrow")
                        {
                            var b = LogicWrapper.GetFileCatPageRight(ents, false, nextUpperIndex, currentPage, total, pageItems);
                            nextUpperIndex = b.nextStartIndex;
                            nextLowerIndex = b.prevIndex;
                            currentPage = b.currentPage;

                            UIDraw.DrawCatFilesPage(currentPage, total, b.filesArr, path);

                        }
                        if (a.Key.ToString() == "LeftArrow")
                        {
                            //
                            var b = LogicWrapper.GetFileCatPageLeft(ents, false, nextLowerIndex, currentPage, total, pageItems);
                            nextUpperIndex = b.nextUpperIndex;
                            nextLowerIndex = b.nextLowerIndex;
                            currentPage = b.currentPage;

                            UIDraw.DrawCatFilesPage(currentPage, total, b.filesArr, path);
                        }
                        if (a.Key.ToString() == "Escape")
                        {
                            working = false;
                        }
                    }
                }
                catch
                {
                    UIDraw.WriteMessage("Во время работы с папкой что-то пошло не так, попробуйте заного ввести команду.");
                }
            }
            else
            {
                UIDraw.WriteMessage("Такой папки не существует");
            }
        }
    }
}
