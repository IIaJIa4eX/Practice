using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Exercise1_OOP
{
    public class BuildingWrapper
    {

        


        protected class Building
        {
            private int _number;
            private int _height;
            private int _floors;
            private int _apartamentsAmount;
            private int _sectionsNumber;
            private static int _numbGenerator;
            private int _distanceBetweenFloors = 3;
            private int _totalFloorApartamentsNumber;



            public  Building(int floors, int apartamentsAmount, int sectionsNumber, int distanceBetweenFloors)
            {
                _floors = floors;
                _apartamentsAmount = apartamentsAmount;
                _sectionsNumber = sectionsNumber;
                _distanceBetweenFloors = distanceBetweenFloors;

                _number = _numbGenerator++;
            }

            public int GetFloorHeight(int floor)
            {
                if (floor > _floors)
                {
                    return 0;
                }

                return floor * _distanceBetweenFloors;
            }

            public int GetSectionAppartamentsAmount()
            {
                return _totalFloorApartamentsNumber * _floors;
            }



            public int TotalFloorAppartamentsAmount
            {
                get
                {
                    return _totalFloorApartamentsNumber;
                }
                set
                {
                    _totalFloorApartamentsNumber = value;
                }
            }

            public int Number
            {
                get
                {
                    return _number;
                }
            }
            public int Height
            {
                get
                {
                    return _height * _distanceBetweenFloors;
                }
                set
                {
                    _height = value;
                }
            }

            public int Floors
            {
                get
                {
                    return _floors;
                }
                set
                {
                    _floors = value;
                }
            }

            public int ApartamentsAmount
            {
                get
                {
                    return _apartamentsAmount;
                }
                set
                {
                    _apartamentsAmount = value;
                }
            }


            public int SectionsNumber
            {
                get
                {
                    return _sectionsNumber;
                }
                set
                {
                    _sectionsNumber = value;
                }
            }

            public int DistanceBetweenFloors
            {
                get
                {
                    return _distanceBetweenFloors;
                }
                set
                {
                    _distanceBetweenFloors = value;
                }
            }
        }

    }
}
