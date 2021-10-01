using System;

namespace GetMounthNameByNumber
{
    class GetMounthName
    {

        //Скажите на следующем стриме, какой тип у переменной в Enum'е, т.е, какой тип у названия 'Январь', либо, напишите мне в комментах, пожалуйста.
        //ДАННЫЙ ПРОЕКТ СОДЕРЖИТ ЗАДАНИЕ ПРО ДОЖДЛИВУЮ ЗИМУ.
        enum Mounth
        {
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Здравсвуйте, в этой программе вы можете узнать название месяца по его номеру, а так же \n" +
                               "среднесуточную температуру за день, в этом месяце.");

            Console.WriteLine("Укажите порядковый номер месяца:");

            byte monthNumber = Convert.ToByte(Console.ReadLine());

            Console.WriteLine($"Ваш месяц {Enum.GetName(typeof(Mounth), monthNumber)}");
            Console.WriteLine("Введите минимальную температуру за сутки!");

            int minTemp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Окей! Теперь введите максимальную температуру за сутки!");

            int maxTemp = Convert.ToInt32(Console.ReadLine());
            int evrTemp = (maxTemp + minTemp) / 2;


            if ((monthNumber == (byte)Mounth.Декабрь || monthNumber == (byte)Mounth.Январь || monthNumber == (byte)Mounth.Февраль) && evrTemp > 0)
            {
                Console.WriteLine($"Чтож, у Вас дождливая зима! Среднесуточная температура равна {evrTemp}!");
            }
            else
            {
                Console.WriteLine($"Среднесуточная температура равна {evrTemp}!");
            }
        }
    }
}
