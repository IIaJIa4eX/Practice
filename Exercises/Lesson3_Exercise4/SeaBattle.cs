using System;

namespace SeaBattleField
{
    class SeaBattle
    {
        static void Main(string[] args)
        {
            var field = new string[12, 12];

            var horChars = new string[] {"А","Б","В","Г", "Д", "Е", "Ж", "З", "И", "К" };


            field[2, 1] = "X";
            field[2, 2] = "X";
            field[4, 10] = "X";
            field[5, 10] = "X";
            field[6, 10] = "X";
            field[9, 2] = "X";
            field[9, 3] = "X";
            field[9, 4] = "X";
            field[9, 5] = "X";
            field[4, 4] = "X";
            field[4, 3] = "X";

          /*   А Б В Г Д Е Ж З И К
            1  O O O O O O O O O O
            2  O O O O O O O O O O
            3  X X O O O O O O O O
            4  O O O O O O O O O O
            5  O O X X O O O O O X
            6  O O O O O O O O O X
            7  O O O O O O O O O X
            8  O O O O O O O O O O
            9  O O O O O O O O O O
            10 O X X X X O O O O O
          */


            for (var i = 0; i < field.GetUpperBound(0) -1 ; i++)
            {

                if(i == 0)
                {
                    for (var h = 0; h < horChars.Length; h++)
                    {

                        Console.Write(h == 0 ? "   " + horChars[h] + " " : horChars[h] + " ");

                    }

                    Console.WriteLine();
                }

                for (var j = 0; j < field.GetUpperBound(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write(i + 1 >= 10 ? $"{i + 1}" + " " : $"{i + 1}" + "  ");
                    }
                    else
                    {

                        Console.Write(j != 0 && field[i, j] != "X" ? $"O " : "X ");
                    }

                }

                Console.WriteLine();
            }

        }
    }
}
