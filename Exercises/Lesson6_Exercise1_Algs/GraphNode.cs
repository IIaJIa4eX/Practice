using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Exercise1_Algs
{
     class GraphNode
    {
        public int Value { get; set; }
        public List<GraphEdge> Edges { get; set; }

        public GraphNode()
        {
            Edges = new List<GraphEdge>();
        }

        public bool isUsed { get; set; } = false;

    }
}
