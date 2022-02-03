using System;
using System.Collections;

namespace Lesson6_Exercise1_Algs
{
    class Program
    {
        static void Main(string[] args)
        {

         
            var getTree = new CreateTrees();

            //Граф

            //  --->(2)------->(5)
            //  |    ↓          ↑
            // (1)  (4)         |
            //  |    ↑          ↓
            //  --->(3)------->(6)


            //Обход в ширину
            var queTree = new Queue();
            var nodeBFS = getTree.GetRoot_CreateGraph();
            queTree.Enqueue(nodeBFS);

            while (queTree.Count != 0)
            {
                GraphNode tmp = (GraphNode)queTree.Dequeue();
                tmp.isUsed = true; // для первой вершины

                Console.WriteLine(tmp.Value);

                if (tmp.Edges.Count != 0)
                {
                    foreach(var edge in tmp.Edges)
                    {
                        if (!edge.Node.isUsed)
                        {
                            edge.Node.isUsed = true;
                            queTree.Enqueue(edge.Node);
                        }
                    }
                }

            }

            Console.WriteLine("_____________________________");
            Console.WriteLine("Глубина");

            //Обход в глубину
            var stackTree = new Stack();
            var nodeDFS = getTree.GetRoot_CreateGraph();

            stackTree.Push(nodeDFS);

            while (stackTree.Count != 0)
            {
                GraphNode tmp = (GraphNode)stackTree.Pop();
                tmp.isUsed = true; // для первой вершины

                Console.WriteLine(tmp.Value);

                if (tmp.Edges.Count != 0)
                {
                    foreach (var edge in tmp.Edges)
                    {
                        if (!edge.Node.isUsed)
                        {
                            edge.Node.isUsed = true;
                            stackTree.Push(edge.Node);
                        }
                    }
                }

            }
        }
    }
}
