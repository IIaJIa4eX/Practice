using System;

namespace Lesson2_Exercise1_Algs
{
    class Program
    {

        public class Node : ILinkedList
        {

            private Node NodeFirst { get; set; }



            public int Value { get; set; }
            public Node NextNode { get; set; } = null;
            public Node PrevNode { get; set; } = null;




            public void AddNode(int value)
            {

                if (NodeFirst == null)
                {
                    NodeFirst = new Node { Value = value };
                }
                else
                {
                    var currentNode = NodeFirst;

                    while (currentNode.NextNode != null)
                    {
                        currentNode = currentNode.NextNode;
                    }

                    var newNode = new Node { Value = value, PrevNode = currentNode };
                    currentNode.NextNode = newNode;
                }

            }

            public void AddNodeAfter(Node node, int value)
            {

                var newNode = new Node {Value = value};
                var nextNode = node.NextNode;

                if(nextNode != null)
                {
                    nextNode.PrevNode = newNode;
                    newNode.PrevNode = node;
                    node.NextNode = newNode;
                    newNode.NextNode = nextNode;
                }
                else
                {
                    node.NextNode = newNode;
                    newNode.PrevNode = node;
                }
               
            }


            public Node FindNode(int searchValue)
            {
                bool searching = true;
                var currentNode = NodeFirst;

                if(currentNode.Value == searchValue)
                {
                    return currentNode;
                }

                while (searching)
                {
                    
                    if(currentNode.Value == searchValue)
                    {
                        return currentNode;
                    }

                    if(currentNode.NextNode == null)
                    {
                        return null;
                    }

                    currentNode = currentNode.NextNode;
                }

                return null;
            }

            public int GetCount()
            {
                int count = 0;

                var currentNode = NodeFirst;
                if (currentNode != null)
                {
                    count = 1;
                    while (currentNode.NextNode != null)
                    {
                        currentNode = currentNode.NextNode;
                        count++;
                    }
                }
                return count;
            }

            public void RemoveNode(int index)
            {
                int count;
                bool searching = true;
                var currentNode = NodeFirst;

                if (currentNode != null)
                {
                    count = 1;
                    while (searching)
                    {
                        if(count == index)
                        {
                            if(currentNode.NextNode == null && currentNode.PrevNode == null)
                            {
                                NodeFirst = null;
                                return;
                            }
                            var nextnode = currentNode.NextNode;
                            var prevnode = currentNode.PrevNode;

                            if(nextnode != null)
                            {
                                nextnode.PrevNode = currentNode.PrevNode;
                            }
                            if (prevnode != null)
                            {
                                prevnode.NextNode = currentNode.NextNode;
                            }

                        }

                        if (currentNode.NextNode != null)
                        {
                            currentNode = currentNode.NextNode;

                            count++;
                        }
                        else
                        {
                            return;
                        }
                       
                    }
                }
            }

            public void RemoveNode(Node node)
            {

                if( node.NextNode == null && node.PrevNode == null)
                {
                    NodeFirst = null;
                    return;
                }

                if(node.NextNode != null)
                {
                    if (node.PrevNode == null)
                    {
                        NodeFirst = node.NextNode;
                    }

                    node.NextNode.PrevNode = null;

                    node.NextNode = null;
                }
                if (node.PrevNode != null)
                {
                    node.PrevNode.NextNode = node.NextNode;
                    node.PrevNode = null;
                }
            }
        }


        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }



        static void Main(string[] args)
        {
            var list = new Node();
            list.AddNode(555);
            list.AddNode(666);
            list.AddNode(777);
            list.AddNode(888);

            var item = list.FindNode(888);
            Console.WriteLine(item.Value);

            Console.WriteLine(list.GetCount());

            list.AddNodeAfter(list.FindNode(555), 444);

            Console.WriteLine(list.FindNode(444).Value);

            Console.WriteLine(list.GetCount());

            list.RemoveNode(2);

            Console.WriteLine(list.GetCount());

            list.RemoveNode(list.FindNode(555));

            Console.WriteLine(list.GetCount());

        }
    }
}
