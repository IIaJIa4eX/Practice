using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Exercise2_Algs
{
    public class TreeLogic : ITree
    {

        TreeNode Root { get; set; } = null;


        public void AddItem(int value)
        {

            if(Root == null)
            {
                Root = new TreeNode { Value = value };
                return;
            }

            var currentNode = Root;

            while (currentNode != null)
            {
                if (value > currentNode.Value)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;

                    }
                    else
                    {
                        currentNode.RightChild = new TreeNode { Value = value, Parent = currentNode };
                        return;
                    }
                }
                else
                {

                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;

                    }
                    else
                    {
                        currentNode.LeftChild = new TreeNode { Value = value, Parent = currentNode };
                        return;
                    }
                }


            }

            throw new NullReferenceException();
        }



        public TreeNode GetNodeByValue(int value)
        {
            if(Root == null)
            {
                return null;
            }

            var currentNode = Root;

            while(currentNode != null)
            {
                if(currentNode.Value == value)
                {
                    return currentNode;
                }

                if (value > currentNode.Value)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;

                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {

                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;

                    }
                    else
                    {
                        return null;
                    }
                }

            }

            return null;

        }

        public TreeNode GetRoot()
        {
            return Root;
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            var currentNode = GetNodeByValue(value);

            if(currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    //Корень
                    if (currentNode.Parent == null && currentNode.LeftChild == null && currentNode.RightChild == null)
                    {
                        Root = null;
                        return;
                    }
                    if (currentNode.Parent == null && currentNode.RightChild != null && currentNode.LeftChild == null)
                    {
                        Root = currentNode.RightChild;
                        Root.Parent = null;
                        currentNode.RightChild = null;                       
                        return;
                    }
                    if (currentNode.Parent == null && currentNode.RightChild == null && currentNode.LeftChild != null)
                    {
                        Root = currentNode.LeftChild;
                        Root.Parent = null;
                        currentNode.LeftChild = null;
                        return;
                    }
                    //Листья
                    //Если у узла нет наследников, то удаляем ссылку на него, у его родителя.
                    if (currentNode.Parent != null && currentNode.LeftChild == null && currentNode.RightChild == null)
                    {
                        if (currentNode.Equals(currentNode.Parent.LeftChild))
                        {
                            currentNode.Parent.LeftChild = null;
                            return;
                        }
                        else if (currentNode.Equals(currentNode.Parent.RightChild))
                        {
                            currentNode.Parent.RightChild = null;
                            return;
                        }

                        throw new Exception("Something goes wrong! Imposible to delete current item.");
                    }

                    //Если у узла есть только левый наследник, то он становится на место удаляемого узла.
                    if (currentNode.Parent != null && currentNode.LeftChild != null && currentNode.RightChild != null)
                    {
                        

                        throw new Exception("Something goes wrong! Imposible to delete current item.");
                    }


                }

            }
        }
    }
}
