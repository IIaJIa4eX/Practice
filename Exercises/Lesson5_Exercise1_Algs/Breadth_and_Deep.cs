using System;
using System.Collections;

namespace Lesson5_Exercise1_Algs
{
    class Breadth_and_Deep
    {
        static void Main(string[] args)
        {
            var tree = new TreeLogic_Coll();
            tree.AddItem(13);
            tree.AddItem(11);
            tree.AddItem(15);
            tree.AddItem(10);
            tree.AddItem(12);
            tree.AddItem(14);
            tree.AddItem(16);


            Console.WriteLine("Ширина");
            var queTree = new Queue();
            //Обход в ширину
            var current = tree.GetRoot();
            queTree.Enqueue(current);

            while(queTree.Count != 0)
            {
                TreeNode_Coll tmp = (TreeNode_Coll)queTree.Dequeue();
                Console.WriteLine(tmp.Value);

                if(tmp.LeftChild != null)
                {
                    queTree.Enqueue(tmp.LeftChild);
                }
                if (tmp.RightChild != null)
                {
                    queTree.Enqueue(tmp.RightChild);
                }

            }

            Console.WriteLine("_____________________________");
            Console.WriteLine("Глубина");
            //Обход в глубину
            var stackTree = new Stack();
            stackTree.Push(current);
            while (stackTree.Count != 0)
            {

                TreeNode_Coll tmp = (TreeNode_Coll)stackTree.Pop();
                Console.WriteLine(tmp.Value);

                if (tmp.RightChild != null)
                {
                    stackTree.Push(tmp.RightChild);
                }
                if (tmp.LeftChild != null)
                {
                    stackTree.Push(tmp.LeftChild);
                }

            }
        }
    }
}
