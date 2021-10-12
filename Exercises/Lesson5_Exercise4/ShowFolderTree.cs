using System;
using System.IO;

namespace Lesson5_Exercise4
{
    class ShowFolderTree
    {


        public static void ShowDirectory(string directory, ref string path)
        {


            if (directory == "")
            {
                return;
            }

            File.AppendAllText(path, $"{directory} {Environment.NewLine}"); ;

            string[] sub = Directory.GetFileSystemEntries(directory, "*", SearchOption.TopDirectoryOnly);


            for (int i = 0; i < sub.Length; i++)
            {

                if (!sub[i].Contains("."))
                {
                    ShowDirectory(sub[i], ref path);

                }

                else
                {
                    File.AppendAllText(path, $"{sub[i]} {Environment.NewLine}");
                }

            }

            return;

        }


        static void Main(string[] args)
        {
            string fileName = "Tree.txt";

            string userName = Environment.UserName;

            string folderName = "MainDirectory";


            string path = $@"C:\Users\{userName}\Desktop\{fileName}";

            string dirPath = $@"C:\Users\{userName}\Desktop\{folderName}";


            string[] directory = Directory.GetFileSystemEntries(dirPath, "*", SearchOption.AllDirectories);


            for (int i = 0; i < directory.Length; i++)
            {
                File.AppendAllText(path, $"{directory[i]} {Environment.NewLine}");
            }

            File.AppendAllText(path, $"_________________________________________________________________________ {Environment.NewLine}");

            ShowDirectory(dirPath, ref path);

        }
    }
}
