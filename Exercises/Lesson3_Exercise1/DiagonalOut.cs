using System;

namespace DiagonalArrayItemsOut
{
    class DiagonalOut
    {
        static void Main(string[] args)
        {
            var dd = new int [5,5];

            dd[0, 0] = 1;
            dd[1, 1] = 2;
            dd[2, 2] = 3;
            dd[3, 3] = 4;
            dd[4, 4] = 5;
            

            var counter = 0;

            for (int i = 0;  i < dd.GetLength(0); i++)
            {
                
                for (int j = 0; j < 1 && counter < dd.GetLength(1); j ++)
                {

                    Console.WriteLine(dd[i, counter++]);

                }

                
            }
           
        }
    }
}
