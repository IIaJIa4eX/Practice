using System;
using System.Diagnostics;

namespace Lesson6_Exercise1
{


    public static class ProcessHandler
    {

        private static string commands = ">help >gpbi >gpbn >killpbi >gprlist";


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
                        ShowAllCommands();
                        break;

                    case ">gpbi":
                        GetProcessById(splitedStr[1].Trim());
                        break;

                    case ">gpbn":
                        GetProcessByName(splitedStr[1].Trim());
                        break;

                    case ">killpbi":
                        KillProcessById(splitedStr[1].Trim());
                        break;

                    case ">gprlist":
                        GetAllProcesses();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Не удалось распознать команду, если вы забыли команды нажмите >help");
                return;
            }

        }



        private static void GetAllProcesses()
        {
            var processes = Process.GetProcesses();

            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine($"{processes[i].Id}  _ {processes[i].ProcessName}");
            }

        }

        private static void GetProcessById(string processId)
        {
            int id;
            try
            {
                id = Convert.ToInt32(processId);
            }
            catch
            {
                Console.WriteLine($"Айдишник {processId} - не соответсвует формату");
                return;
            }


            try
            {

                var process = Process.GetProcessById(id);

                Console.WriteLine($"Имя: {process.ProcessName} Время запуска:{process.StartTime}  UserProcessorTime: {process.UserProcessorTime}");

            }
            catch
            {
                Console.WriteLine($"Процесс {id} не найден");
            }

        }

        private static void GetProcessByName(string processname)
        {


            if (string.IsNullOrEmpty(processname))
            {
                Console.WriteLine("Вы не ввели имя процесса");
                return;
            }


            try
            {
                var process = Process.GetProcessesByName(processname);

                for (int i = 0; i < process.Length; i++)
                {

                    Console.WriteLine($"Айди:{process[i].Id} Имя:{process[i].ProcessName} Время запуска:{process[i].StartTime}  UserProcessorTime: {process[i].UserProcessorTime}");


                }

            }
            catch
            {
                Console.WriteLine("Процесс не найден");
            }


        }

        private static void KillProcessById(string processId)
        {

            int id;
            try
            {
                id = Convert.ToInt32(processId);
            }
            catch
            {
                Console.WriteLine($"Айдишник {processId} - не соответсвует формату");
                return;
            }


            try
            {
                var process = Process.GetProcessById(id);

                process.Kill();

                Console.WriteLine($"Процесс под номером: {processId}  - {process.ProcessName} успешно закрыт");
            }
            catch
            {
                Console.WriteLine($"Не удалось завершить процесс под номером: {processId}");
            }

        }

        private static void ShowAllCommands()
        {
            Console.WriteLine(">gpbi Получить инфо по процессу используя его Айди -  gpbi [айди]");
            Console.WriteLine(">gpbn Получить инфо по процессам используя имена/имя");
            Console.WriteLine(">killpbi Кильнуть процесс по айди");
            Console.WriteLine(">gprlist Получить список процессов");
        }



    }


    class ProcessManager
    {


        static void Main(string[] args)
        {
            bool working = true;

            Console.WriteLine("Здравсвуйте, Вы используете менеджер процессов!");
            Console.WriteLine(@"Чтобы узнать, какие команды доступны - нажмите '>help' ");


            while (working)
            {


                ProcessHandler.CommandHandler(Console.ReadLine());


            }


        }
    }
}
