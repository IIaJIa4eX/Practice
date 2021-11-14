using System;

namespace Lesson4_Exercise2_Algs
{
    class Program
    {
        static void Main(string[] args)
        {


            var tree = new TreeLogic();
            tree.AddItem(10);
            tree.AddItem(11);
            tree.AddItem(9);
            tree.AddItem(6);
            tree.AddItem(5);
            tree.AddItem(30);
            tree.AddItem(12);
            tree.AddItem(15);

            var node = tree.GetNodeByValue(5);
            bool ss = true;
            
        }
    }
}
