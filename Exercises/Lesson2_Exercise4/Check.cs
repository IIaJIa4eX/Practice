using System;

namespace ShowCheckInfo
{
    class Check
    {
        static void Main(string[] args)
        {

            byte pm = 1;
            string orgName = "ЦБТ";
            int sellNumb = 00314862;
            int chikenPrice = 250;
            int saladPrice = 100;
            byte posNumber = 2;
            byte purchNumber = 2;




            Console.WriteLine($"         ДОБРО ПОЖАЛОВАТЬ!         " + "\n" +
                              $"РМ№{1}         Администратор 01 {orgName}" + "\n" +
                              $"ПРОДАЖА №{sellNumb}         Смена№174" + "\n" +
                              $"1. Филе курицы в мед. соусе         " + "\n" +
                              $"  1*250_ _ _ _ _ _ _ _ _ _ _ _{chikenPrice}" + "\n" +
                              $"_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" + "\n" +
                              $"2. Салат корейский                  " + "\n" +
                              $"  1*100_ _ _ _ _ _ _ _ _ _ _ _{saladPrice}" + "\n" +
                              $"_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" + "\n" +
                              $"Позиций: {posNumber}              Покупок:{purchNumber}" + "\n" +
                              $"Сумма_ _ _ _ _ _ _ _ _ _ _ _ _{chikenPrice + saladPrice}" + "\n" +
                              $"ИТОГ                          {chikenPrice + saladPrice}" + "\n" +
                              $"             СПАСИБО               " + "\n" +
                              $"           ЗА ПОКУПКУ!            ");
        }
    }
}
