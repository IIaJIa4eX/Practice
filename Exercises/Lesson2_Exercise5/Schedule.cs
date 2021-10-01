using System;

namespace OfficeScheduler
{
    class Schedule
    {
        [Flags]
        enum WorkDays
        {

            Понедельник = 0b_0000001,
            Вторник =     0b_0000010,
            Среда =       0b_0000100,
            Четверг =     0b_0001000,
            Пятница =     0b_0010000,
            Суббота =     0b_0100000,
            Воскресение = 0b_1000000
        }

        static void Main(string[] args)
        {
            
            WorkDays Office1 = (WorkDays)0b_0000111;

            WorkDays Office2 = (WorkDays)0b_0111000;

            WorkDays Office3 = WorkDays.Воскресение | WorkDays.Понедельник;
            

            Console.WriteLine($"Оффис №1 работает : {Office1}");
            Console.WriteLine($"Оффис №2 работает : {Office2}");
            Console.WriteLine($"Оффис №3 работает : {Office3}");

        }
    }
}

