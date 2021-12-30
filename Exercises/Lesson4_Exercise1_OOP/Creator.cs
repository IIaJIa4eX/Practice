using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Exercise1_OOP
{
     public  class Creator : BuildingWrapper
    {
        private static Hashtable _buildings;

        public class BuildingInfo
        {
            

            public int number;
            public int height;
            public int floors;
            public int apartamentsAmount;
            public int sectionsNumber;
            public int distanceBetweenFloors;
            public int totalFloorApartamentsNumber;

            public BuildingInfo(int number, int height, int floors, int apartamentsAmount, int sectionsNumber, int distanceBetweenFloors, int totalFloorApartamentsNumber)
            {
                this.number = number;
                this.height = height;
                this.floors = floors;
                this.apartamentsAmount = apartamentsAmount;
                this.sectionsNumber = sectionsNumber;
                this.distanceBetweenFloors = distanceBetweenFloors;
                this.totalFloorApartamentsNumber = totalFloorApartamentsNumber;
            }
        }


        public Creator()
        {

            _buildings = new Hashtable();
        }

       
        public static void  CreateBuilding(int floors, int apartamentsAmount, int sectionsNumber, int distanceBetweenFloors)
        {
            var building = new Building(floors, apartamentsAmount, sectionsNumber, distanceBetweenFloors);

            _buildings.Add(building.Number, building);
        }

        public static BuildingInfo GetBuildingByNumber(int number)
        {
            var building = (Building)_buildings[number];

            BuildingInfo tmp = new BuildingInfo(building.Number, building.Height,building.Floors ,building.ApartamentsAmount, building.SectionsNumber, building.DistanceBetweenFloors, building.TotalFloorAppartamentsAmount);
            return tmp;
        }

        public static Hashtable GetAllBuildings()
        {
            var gg = _buildings;

            return gg;
        }

        public static int GetFloorHeight(BuildingInfo info, int floornumber)
        {
            var building = (Building)_buildings[info.number];

            return building.GetFloorHeight(floornumber);
        }

        public static int GetSectionAppartamentsAmount(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];

            return building.GetSectionAppartamentsAmount();
        }

        public static void DeleteBuildingByNumber(int number)
        {
            _buildings.Remove(number);
        }

        public static int GetTotalFloorAppartamentsAmount(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];

            return building.TotalFloorAppartamentsAmount;
        }

        public static void SetTotalFloorAppartamentsAmount(BuildingInfo info, int totaFloorApparaments)
        {
            var building = (Building)_buildings[info.number];
            info.totalFloorApartamentsNumber = totaFloorApparaments;
            building.TotalFloorAppartamentsAmount = totaFloorApparaments;
        }

        public static int GetHeight(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];
            return building.Height;
        }

        public static void SetHeight(BuildingInfo info, int height)
        {
            var building = (Building)_buildings[info.number];
            info.height = height;
            building.Height = height;
        }

        public static int GetFloors(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];
            return building.Floors;
        }

        public static void SetFloors(BuildingInfo info, int floors)
        {
            var building = (Building)_buildings[info.number];
            info.floors = floors;
            building.Floors = floors;
        }

        public static int GetApartamentsAmount(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];
            return building.ApartamentsAmount;
        }

        public static void SetApartamentsAmount(BuildingInfo info, int apartamentsAmount)
        {
            var building = (Building)_buildings[info.number];
            info.apartamentsAmount = apartamentsAmount;
            building.ApartamentsAmount = apartamentsAmount;
        }

        public static int GetSectionsNumber(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];
            return building.SectionsNumber;
        }

        public static void SetSectionsNumber(BuildingInfo info, int sectionsNumber)
        {
            var building = (Building)_buildings[info.number];
            info.sectionsNumber = sectionsNumber;
            building.SectionsNumber = sectionsNumber;
        }

        public static int GetDistanceBetweenFloors(BuildingInfo info)
        {
            var building = (Building)_buildings[info.number];
            return building.DistanceBetweenFloors;
        }

        public static void SetDistanceBetweenFloors(BuildingInfo info, int distanceBetweenFloors)
        {
            var building = (Building)_buildings[info.number];
            info.distanceBetweenFloors = distanceBetweenFloors;
            building.DistanceBetweenFloors = distanceBetweenFloors;
        }

    }
}
