using System;

namespace EverageDayTemperature
{
    class AverageDayTemp
    {
        static void Main(string[] args)
        {
            Console.WriteLine
                (
                "Здравствуйте, вы в программе для расчёта среднесуточной температуры!\n" +
                "Для того, чтобы начать, введите минимальную температуру за сутки:"
                );

            int minTemp =  Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Замечательно! Теперь введите максимальную температуру за сутки!");

            int maxTemp = Convert.ToInt32(Console.ReadLine());

            if (minTemp == 0 && maxTemp == 0)
            {
                Console.WriteLine("Окей, среднесуточная температура за сутки равна 0!");
            }
            else
            {
                int evrTemp = (maxTemp + minTemp) / 2;
                Console.WriteLine($"Окей, среднесуточная температура за сутки равна {evrTemp}!");
            }
        }
    }
}
