using System;
using System.Collections;

namespace Lesson4_Exercise1_OOP
{
     class Program
    {

        

        static void Main(string[] args)
        {

            var creator = new Creator();
            Creator.CreateBuilding(9,36,1,3);
            Creator.CreateBuilding(9, 36, 1, 3);
            Creator.CreateBuilding(9, 36, 1, 3);
            Creator.CreateBuilding(9, 36, 1, 3);


            var buildings = Creator.GetAllBuildings();

            Console.WriteLine($"Всего домов: {buildings.Count}.");
            foreach (DictionaryEntry item in buildings)
            {

                Console.WriteLine($"\tНомер здания: {item.Key}." );
            }

            var building1 = Creator.GetBuildingByNumber(0);
            var building2 = Creator.GetBuildingByNumber(1);
            var building3 = Creator.GetBuildingByNumber(2);
            var building4 = Creator.GetBuildingByNumber(3);

            Console.WriteLine($"Высота пятого этажа у дома равна: { Creator.GetFloorHeight(building1, 5)}м");
            Creator.SetDistanceBetweenFloors(building2, 4);//меняем дистанцию между этажами
            Console.WriteLine($"Дистанция между этажами у 1 дома, после изменения, равна: {Creator.GetDistanceBetweenFloors(building2)}");
            Console.WriteLine($"К сожалению, пришлось удалить дом, под номером 3");
            Creator.DeleteBuildingByNumber(3);


            Console.WriteLine($" После этого осталось всего {buildings.Count} дома.");
            foreach (DictionaryEntry item in buildings)
            {

                Console.WriteLine($"\tНомер здания: {item.Key}.");
            }


        }
    }
}
