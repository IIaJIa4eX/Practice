using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_Exercise1_Algs
{

    public class TreeNode_Coll
    {
        public int Value { get; set; }
        public TreeNode_Coll LeftChild { get; set; }
        public TreeNode_Coll RightChild { get; set; }
        public TreeNode_Coll Parent { get; set; }


        public override bool Equals(object obj)
        {
            var node = obj as TreeNode_Coll;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }

}
