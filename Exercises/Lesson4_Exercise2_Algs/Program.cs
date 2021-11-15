using System;

namespace Lesson4_Exercise2_Algs
{
<<<<<<< HEAD



    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }


    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }














    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
=======
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
            
>>>>>>> 61fd57daab8e7ab082602eddaa09d095b967fe52
        }
    }
}
