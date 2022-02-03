using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_Exercise1_OOP
{
    sealed class CommandLineParser
    {
        private static string commands = ">help >cpd >dld >cpf >dlf >gdi >gfi >showfullinf >exit >settings";

        FileCatManipulation FC;


        public CommandLineParser()
        {
            FC = new FileCatManipulation();
        }

        public bool CommandHandler(string com)
        {
            bool isworking = true;
            if (string.IsNullOrWhiteSpace(com))
            {
                Console.WriteLine("Не удалось распознать команду, если вы забыли команды нажмите >help");
                return true;
            }

            var splitedStr = com.Trim().Split("<");

            if (commands.Contains(splitedStr[0]))
            {

                switch (splitedStr[0].Trim())
                {
                    case ">help":
                        UIDraw.ShowHelp();
                        break;

                    case ">cpd":
                        if (splitedStr.Length == 3)
                        {
                            FC.CopyFolder(splitedStr[1], splitedStr[2]);
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы скопировать папку введите >cpd<[полный путь к папке]<[куда скопировать, в какую папку, с каким именем]");
                        }
                        break;

                    case ">dld":
                        if (splitedStr.Length == 2)
                        {
                            FC.DeleteFolder(splitedStr[1]);
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы удалить папку введите >dld<[полный путь к папке]");
                        }
                        break;

                    case ">cpf":
                        if (splitedStr.Length == 3)
                        {
                            FC.CopyFile(splitedStr[1], splitedStr[2]);
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы скопировать файл введите >cpf<[полный путь к файлу]<[куда скопировать, с каким именем]");
                        }
                        break;

                    case ">dlf":
                        if (splitedStr.Length == 2)
                        {
                            FC.DeleteFile(splitedStr[1]);
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы удалить файл введите >dlf<[полный путь к файлу]");
                        }
                        break;

                    case ">gdi":
                        if (splitedStr.Length == 2)
                        {
                            UIDraw.WriteMessage(FC.GetDirectoryInfo(splitedStr[1]));
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы получить информацию о директории введите >gdi<[полный путь к директории]");
                        }
                        break;

                    case ">gfi":
                        if (splitedStr.Length == 2)
                        {
                            UIDraw.WriteMessage(FC.GetFileFullInfo(splitedStr[1]));
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы получить информацию о файле введите >gfi<[полный путь к файлу]");
                        }
                        break;

                    case ">showfullinf":

                        if (splitedStr.Length == 2)
                        {
                            FC.ShowFullInformation(splitedStr[1]);
                        }
                        else
                        {
                            UIDraw.WriteMessage("Чтобы получить информацию о директории и список файлов в ней введите >showfullinf<[полный путь к директории]");
                        }

                        break;

                    case ">exit":

                        return false;

                }
            }
            else
            {
                Console.WriteLine("Не удалось распознать команду, если вы забыли команды нажмите >help");
                return true;
            }

            return isworking;
        }
    }
}
