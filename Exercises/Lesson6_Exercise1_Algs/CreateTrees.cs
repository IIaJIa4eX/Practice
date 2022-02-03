using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Exercise1_Algs
{
    class CreateTrees
    {

        
        public GraphNode GetRoot_CreateGraph()
        {
            //Быстро реализовал граф - простите :) 
            var node1 = new GraphNode() { Value = 1 };
            var node2 = new GraphNode() { Value = 2 };
            var node3 = new GraphNode() { Value = 3 };
            var node4 = new GraphNode() { Value = 4 };
            var node5 = new GraphNode() { Value = 5 };
            var node6 = new GraphNode() { Value = 6 };

            node1.Edges.Add(new GraphEdge() { Weight = 0, Node = node2 });
            node1.Edges.Add(new GraphEdge() { Weight = 0, Node = node3 });

            node2.Edges.Add(new GraphEdge() { Weight = 0, Node = node4 });
            node3.Edges.Add(new GraphEdge() { Weight = 0, Node = node4 });

            node2.Edges.Add(new GraphEdge() { Weight = 0, Node = node5 });
            node3.Edges.Add(new GraphEdge() { Weight = 0, Node = node6 });


            node5.Edges.Add(new GraphEdge() { Weight = 0, Node = node6 });
            node6.Edges.Add(new GraphEdge() { Weight = 0, Node = node5 });

            return node1;
        }
    }
}
