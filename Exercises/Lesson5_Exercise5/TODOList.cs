using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lesson5_Exercise5
{

    public class ToDo
    {
        public bool isDone { get; set; }

        public string Title { get; set; }

    }



    class TODOList
    {


        public static List<ToDo> AddTasks(ref List<ToDo> tasks, bool edit)
        {

            while (edit)
            {
                Console.WriteLine("Добавьте название задачи");

                tasks.Add(new ToDo { Title = Console.ReadLine() });

                Console.WriteLine("Добавить еще задачу? Напишите y/n");

                string answer = Console.ReadLine();

                if (answer == "n")
                {
                    edit = false;
                }

            }

            return tasks;
        }

        public static void ShowTasks(ref List<ToDo> tasks)
        {

            int count = 1;

            foreach (var item in tasks)
            {
                Console.WriteLine(item.isDone ? $"{count}_[x] {item.Title}" : $"{count}_{item.Title}");

                count++;
            }
        }

        public static List<ToDo> MarkTasks(ref List<ToDo> tasks)
        {
            bool edit = true;

            while (edit)
            {
                Console.WriteLine("Укажите номер задачи, которую вы хотите отметить");
                int index = Convert.ToInt32(Console.ReadLine());
                int count = 1;

                if (index > tasks.Count || index < 1)
                {
                    Console.WriteLine("Укажите нормальный номер!");
                }
                else
                {
                    foreach (var item in tasks)
                    {
                        if (count == index)
                        {
                            item.isDone = true;
                            count = 1;
                            break;

                        }
                        count++;
                    }

                    ShowTasks(ref tasks);
                }

                Console.WriteLine("закончить форматирование? напишите y/n");
                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    edit = false;
                }
            }

            return tasks;

        }

        public static void SaveTasks(string path, ref List<ToDo> tasks)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(tasks));
        }

        static void Main(string[] args)
        {
            string fileName = "tasks.json";

            string path = $@"C:\Users\{Environment.UserName}\Desktop\{fileName}";

            bool tasksExist, editing = false;

            var tasks = new List<ToDo>();

            bool isWorking = true;

            Console.WriteLine("Проверяем существоавния файла...");

            if (!File.Exists(path))
            {
                Console.WriteLine("Файла нет, создаем файл....");

                File.Create(path);

                Console.WriteLine("Файл создан!");

            }

            while (isWorking)
            {
                Console.WriteLine("Загружаем список задач...");

                string jsn = File.ReadAllText(path);

                    try
                    {
                        tasks = JsonSerializer.Deserialize<List<ToDo>>(jsn);

                        tasksExist = true;

                        Console.WriteLine("Ваш актуальный список задач");

                        ShowTasks(ref tasks);

                    }
                    catch
                    {
                        Console.WriteLine("В файле ничего нет, давайте создадим задачи");

                        AddTasks(ref tasks, true);

                        Console.WriteLine("Это Ваш новый список задач!:");

                        ShowTasks(ref tasks);

                    }

                    Console.WriteLine("Вы хотите сохранить или изменить списко задач?");
                    Console.WriteLine("Нажмите 1, для изменения");
                    Console.WriteLine("Нажмите 2, для сохренения");
                    Console.WriteLine("Нажмите 3 для выхода");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        editing = true;

                        while (editing)
                        {
                            Console.WriteLine("Что Вы хотите сделать с задачами?");
                            Console.WriteLine("Нажмите 1, для добавления задачи");
                            Console.WriteLine("Нажмите 2, для того, чтобы отметить как сделанную");
                            Console.WriteLine("Для выхода нажмите 3");

                            int choice1 = Convert.ToInt32(Console.ReadLine());
                            if (choice1 == 1)
                            {
                                ShowTasks(ref tasks);
                                AddTasks(ref tasks, true);
                                SaveTasks(path, ref tasks);
                        }
                            if (choice1 == 2)
                            {
                                ShowTasks(ref tasks);
                                MarkTasks(ref tasks);
                                SaveTasks(path, ref tasks);
                        }
                            if (choice1 == 3)
                            {
                                editing = false;
                                SaveTasks(path, ref tasks);
                        }
                        }
                    }
                    if (choice == 2)
                    {
                        SaveTasks(path, ref tasks);
                    }

                    if (choice == 3)
                    {
                        isWorking = false;
                    }


              
            }
        }
    }
}

