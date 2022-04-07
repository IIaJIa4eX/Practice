using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1_ex_1_API_micro.Logic
{
    public class ValuesHolder
    {
        private Dictionary<string, string> weatherDic;

        public ValuesHolder()
        {
            weatherDic = new Dictionary<string, string>();
            TempGeneration();
        }

        private void TempGeneration()
        {
            var rng = new Random();

            for (int i = 0; i < 5; i++)
            {
                weatherDic.Add(DateTime.Now.AddDays(i).ToString(), rng.Next(-20, 55).ToString());
            }
        }


        public string Get()
        {

            return JsonConvert.SerializeObject(weatherDic);
        }

        public bool Add(string date, string temperature)
        {


                try
                {
                    weatherDic.Add(date, temperature);

                }
                catch
                {
                    return false;
                }


            return true;
        }

        public bool Update(string stringToUpdate, string newValue)
        {
            try
            {
                if (weatherDic.ContainsKey(stringToUpdate))
                {
                    weatherDic[stringToUpdate] = newValue;
                }
                else
                {
                    Add(stringToUpdate, newValue);                
                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool Delete(string keyToDelete)
        {
            if (weatherDic.ContainsKey(keyToDelete))
            {
                weatherDic.Remove(keyToDelete);
                return true;
            }

            return false;
        }

        public string GetRangeByMinutes(string fromDate,string toDate)
        {
            Dictionary<string, string> weatherRange = new Dictionary<string, string>();

            DateTime dayFrom = Convert.ToDateTime(fromDate);
            DateTime dayTo = Convert.ToDateTime(toDate);
            DateTime dayT;

            foreach(var day in weatherDic)
            {
                dayT = Convert.ToDateTime(day.Key);

                if (dayT >= dayFrom && dayT <= dayTo)
                {
                    weatherRange.Add(day.Key, day.Value);
                }

            }

            return JsonConvert.SerializeObject(weatherRange);
        }

        public string GetRangeByDays(string fromDate, string toDate)
        {
            Dictionary<string, string> weatherRange = new Dictionary<string, string>();

            DateTime dayFrom_DT = Convert.ToDateTime(Convert.ToDateTime(fromDate).ToShortDateString());
            DateTime dayTo_DT = Convert.ToDateTime(Convert.ToDateTime(toDate).ToShortDateString());
            DateTime dayT_DT;

            foreach (var day in weatherDic)
            {
                dayT_DT = Convert.ToDateTime(Convert.ToDateTime(day.Key).ToShortDateString());

                if (dayT_DT >= dayFrom_DT && dayT_DT <= dayTo_DT)
                {
                    weatherRange.Add(day.Key, day.Value);
                }

            }

            return JsonConvert.SerializeObject(weatherRange);
        }
    }
}