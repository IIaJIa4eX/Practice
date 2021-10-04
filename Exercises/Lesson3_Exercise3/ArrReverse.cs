using System;

namespace ReverseArrayInput
{
    class ArrReverse
    {
        static void Main(string[] args)
        {
            var userString = Console.ReadLine();

            var tmpArr = userString.ToCharArray();

            for (int i = tmpArr.GetUpperBound(0); i >= tmpArr.GetLowerBound(0); i--)
            {
                Console.Write(tmpArr[i]);
            }
        }
    }
}
