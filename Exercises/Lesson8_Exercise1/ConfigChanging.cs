using System;
using System.Configuration;

namespace Lesson8_Exercise1
{
    class ConfigChanging
    {



        static void Main(string[] args)
        {
            bool isOk = false;
            var appSettings = ConfigurationManager.AppSettings;

            var conf = CheckIsEmpty(out string errorMessage);
            if (!conf)
            {
                foreach (var key in appSettings.AllKeys)
                {
                    Console.WriteLine($"Key: {key} Value: {appSettings[key]}");
                }

                isOk = true;
            }
            else
            {
                Console.WriteLine(errorMessage);
            }

            if (isOk)
            {

                AddUpdateAppSettings(appSettings.GetKey(appSettings.Count - 1), Guid.NewGuid().ToString());
 
                Console.WriteLine($"Последняя настройка в App.config");
                ReadSetting(appSettings.GetKey(appSettings.Count - 1));
            }


            static void AddUpdateAppSettings(string key, string value)
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



        static bool CheckIsEmpty(out string errorMessage)
        {
            bool empty = true; ;
            string error = "";

            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    error = "Настроек нет";
                }
                else
                {
                    empty = false;
                }

            }
            catch (ConfigurationErrorsException)
            {
                error = "Что-то пошло нет так";
            }

            errorMessage = error;

            return empty;
        }

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Настройка не найдена";

                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Что-то пошло нет так");
            }
        }

    }
}
