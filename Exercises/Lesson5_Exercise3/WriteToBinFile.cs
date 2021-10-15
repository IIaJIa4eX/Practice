using System;
using System.IO;

namespace Lesson5_Exercise3
{
    class WriteToBinFile
    {
        static void Main(string[] args)
        {

            string fileName = "Lesson5_Exercise3.bin";

            string path = $@"C:\Users\{Environment.UserName}\Desktop\{fileName}";

            var input = Console.ReadLine().Split(" ");

            var btArr = new byte[input.Length];

            for (int i = 0; i < btArr.Length; i++)
            {
                btArr[i] = Convert.ToByte(input[i]);
            }

            File.WriteAllBytes(path, btArr);

            byte[] fromFile = File.ReadAllBytes(path);

            for (int i = 0; i < fromFile.Length; i++)
            {
                Console.Write($"{fromFile[i]} ");
            }


        }
    }
}
