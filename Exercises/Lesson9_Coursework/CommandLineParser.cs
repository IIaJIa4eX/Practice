using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Coursework
{
    class CommandLineParser
    {
        private static string commands = ">help >cpd >dld >cpf >dlf >gdi >gfi >showfullinf";
        private static bool fullMode = false;

        public static void CommandHandler(string com)
        {

            if (string.IsNullOrWhiteSpace(com))
            {
                Console.WriteLine("Не удалось распознать команду, если вы забыли команды нажмите >help");
                return;
            }

            var splitedStr = com.Trim().Split(" ");

            if (commands.Contains(splitedStr[0]) && splitedStr.Length == 2)
            {
                switch (splitedStr[0].Trim())
                {
                    case ">help":
                        UIDraw.ShowHelp();
                        break;

                    case ">cpd":
                        
                        break;

                    case ">dld":
                       // GetProcessByName(splitedStr[1].Trim());
                        break;

                    case ">cpf":
                       // KillProcessById(splitedStr[1].Trim());
                        break;

                    case ">dlf":
                        //GetAllProcesses();
                        break;

                    case ">gdi":
                        //GetAllProcesses();
                        break;

                    case ">gfi":
                        //GetAllProcesses();
                        break;

                    case ">showfullinf":

                        fullMode = true;

                        var ents = Directory.GetFileSystemEntries("", "*", SearchOption.TopDirectoryOnly);
                        int lastIndex = 0;

                        //ManipulationLogic.GetFileCatPageRight(ents, true);

                        while (fullMode)
                        {
                            var a = Console.ReadKey();
                            if(a.Key.ToString() == "RightArrow")
                            {
                               // ManipulationLogic.GetFileCatPageRight(ents, "path", false);
                            }
                            if (a.Key.ToString() == "LeftArrow")
                            {

                            }
                            
                            
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Не удалось распознать команду, если вы забыли команды нажмите >help");
                return;
            }

        }
    }
}
