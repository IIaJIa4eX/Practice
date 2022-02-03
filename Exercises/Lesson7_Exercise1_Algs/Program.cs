using System;

namespace Lesson7_Exercise1_Algs
{
    class Program
    {

        static int vert = 7;
        static int hor = 10;


        static void Print(int v, int h, int [,] field)
        {
            int i, j;
            for ( i = 0; i < v; i++)
            {
                for ( j = 0; j < h; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.Write("\r\n");
            }

        }


        static void Main(string[] args)
        {
            var arr = new int[vert, hor];
            int i, j;
            for(j = 0; j < hor; j++)
            {
                arr[0, j] = 1;

            }
            for(i = 1; i < vert; i++)
            {
                arr[i, 0] = 1;
                for(j = 1; j < hor; j++)
                {
                    arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                }
            }

            Print(vert, hor, arr);
            Console.WriteLine($"Максимальное число маршрутов равно {arr[vert - 1,hor - 1]}");
        }
    }
}
