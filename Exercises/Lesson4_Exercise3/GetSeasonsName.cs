using System;

namespace SeasonName
{
    class GetSeasonsName
    {

        public enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn

        }


        public static  string GetSeasonName(Seasons value)
        {

            string mounthName = " ";

            switch ((byte)value)
            {
                case 0:
                    mounthName = "Зима";
                    break;

                case 1:
                    mounthName = "Весна";
                    break;

                case 2:
                    mounthName = "Лето";
                    break;

                case 3:
                    mounthName = "Осень";
                    break;
            }

            return mounthName;

        }

        public static Seasons GetSeasonNumber(int number)
        {
            var tmpNumb = number;

            if(tmpNumb == 12 || (tmpNumb >= 1 && tmpNumb <= 2))
            {
                return Seasons.Winter;
            }

            if (tmpNumb >= 3 && tmpNumb <= 5)
            {
                return Seasons.Spring;
            }

            if (tmpNumb >= 6 && tmpNumb <= 8)
            {
                return Seasons.Summer;
            }

            return Seasons.Autumn;
        }

        static void Main(string[] args)
        {
            

            bool isDone = false;
                     
            while(!isDone)
            {
                Console.WriteLine("Напишите порядковый номер месяца, чтобы узнать вермя года!");

                var mounthNumb = Convert.ToInt32(Console.ReadLine());

                isDone = mounthNumb > 0 && mounthNumb <= 12 ? true : false;
               
                Console.WriteLine
                    (
                    isDone ?
                    $"{mounthNumb}й месяц - это {GetSeasonName(GetSeasonNumber(mounthNumb))}" :
                    "Ошибка: введите число от 1 до 12!"
                    );
              
            }

        }
    }
}
