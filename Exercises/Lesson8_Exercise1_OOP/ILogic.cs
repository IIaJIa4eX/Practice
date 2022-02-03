using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Exercise1_OOP
{
    interface ILogic
    {
        public void CopyFolderLogic(string sourcePath, string destinationPath);
        public void DeleteFolderLogic(string folderPath);
        public void CopyFileLogic(string sourcePath, string destinationPath);
        public void DeleteFileLogic(string filePath);
        public string GetDirInfo(string path);
        public string GetFileInfo(string path);

    }
}
