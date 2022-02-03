using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Coursework
{
   

      //Класс для работы с настройками пользователя,
    public class UserSettings
    {
        public int pageCount = 20;



        //Метод проверяет, есть ли настройки  у пользователя, если их нет, предлагает ввести, если пользователь отказывается, то ставит настройки по умолчанию.
        public static void UserConsole()
        {
            bool success = false;
            bool success2 = false;
            bool defaultS = false;
            int elemNumber = 20;

            UIDraw.WriteMessage("Привет! На данный момент Вы можете настроить только кол-во отображаемых элементов");

            if (CheckIsEmpty())
            {
                
                UIDraw.WriteMessage("У Вас пустые настройки, поэтому необходми ввести кол-во отображаемых элементов!");
                UIDraw.WriteMessage("Вводите:");

                while (!success)
                {
                    try
                    {
                        string number = Console.ReadLine();
                        if (number == "exit")
                        {                           
                            success = true;
                            defaultS = true;
                        }
                        else
                        {
                            elemNumber = Convert.ToInt32(number);
                            defaultS = false;
                            success = true;
                        }
                    }
                    catch
                    {
                        UIDraw.WriteMessage("Вы должны ввести число!");
                        UIDraw.WriteMessage("Если Вы хотите выйти, тогда напишите exit, применятся настройки по умолчанию");
                    }
                }

                if (defaultS)
                {
                    AddUpdateAppSettings("ElemCount", "20");
                }
                else
                {
                    AddUpdateAppSettings("ElemCount", elemNumber.ToString());
                }

            }
            else
            {
                if (ReadSetting("ElemCount") == "нет ключа")
                {
                    UIDraw.WriteMessage("У Вас пустые настройки, поэтому необходми ввести кол-во отображаемых элементов!");
                    UIDraw.WriteMessage("Вводите:");

                    while (!success2)
                    {
                        try
                        {
                            string number = Console.ReadLine();
                            if (number == "exit")
                            {
                                success2 = true;
                                defaultS = true;
                            }
                            else
                            {
                                elemNumber = Convert.ToInt32(number);
                                success2 = true;
                                defaultS = false;
                            }
                        }
                        catch
                        {
                            UIDraw.WriteMessage("Вы должны ввести число!");
                            UIDraw.WriteMessage("Если Вы хотите выйти, тогда напишите exit, применятся настройки по умолчанию");
                        }
                    }
                    if (defaultS)
                    {
                        AddUpdateAppSettings("ElemCount", "20");
                    }
                    else
                    {
                        AddUpdateAppSettings("ElemCount", elemNumber.ToString());
                    }

                }
                else
                {
                    UIDraw.WriteMessage("Поздравляю! У Вас уже есть настройки кол-во отображаемых элементов!");
                }
                
            }

        }

        //Метод проверяет есть ли настройки
        public static bool CheckIsEmpty()
        {
            bool isEmpty;
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                isEmpty =  true;
                
            }
            else
            {

                isEmpty =  false;
            }

            return isEmpty;
        }
        //Метод выдаёт настройку по ключу, если её нет выдаёт - 'нет ключа'
        public static string ReadSetting(string key)
        {
            string res;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                res = appSettings[key] ?? "нет ключа";

            }
            catch (ConfigurationErrorsException)
            {
                res = $"Не удалось получить настройку {key}";
            }

            return res;
        }

        //Добавляет настроку в конфигурацию, если её нет. Если настрока есть - обновляет её.
        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);

                }
                else
                {
                    settings[key].Value = value;

                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Что-то пошло нет так");
            }
        }
    }
}
