using System;

namespace Lesson4_Exercise2_Algs
{
    class Program
    {
        static void Main(string[] args)
        {


            var tree = new TreeLogic();
            tree.AddItem(13);
            tree.AddItem(11);
            tree.AddItem(15);
            tree.AddItem(10);
            tree.AddItem(12);
            tree.AddItem(14);
            tree.AddItem(16);



            var node = tree.GetNodeByValue(5);
            var root = tree.GetRoot();

            tree.PrintTree(root);
            bool ss = true;

        }
    }
}
