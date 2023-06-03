using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees.BinaryTree
{
    public class BinaryTree<T> : IEnumerable
    {
        public Node<T> Root { get; set; }
        public int Count { get; set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public BinaryTree(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
                Insert(item);
        }

        public T Insert(T value)
        {
            var newNode = new Node<T>(value);

            // Root ?
            if (Root == null)
            {
                Root = newNode;
                Count++;
                return value;
            }

            var list = new List<Node<T>>();
            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                list.Add(temp);
                if (temp.Left != null)
                    q.Enqueue(temp.Left);
                else
                {
                    temp.Left = newNode;
                    Count++;
                    return value;
                }
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
                else
                {
                    temp.Right = newNode;
                    Count++;
                    return value;
                }
            }
            throw new Exception("The insertion operation failed.");
        }

        public static List<T> InOrderIterationTraverse(Node<T> root)
        {

            if (root == null)
                return null;

            var list = new List<T>();
            var stack = new Stack<Node<T>>();
            bool done = false;
            Node<T> currentNode = root;
            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode.Value);
                        currentNode = currentNode.Right;
                    }
                }
            }

            return list;
        }

        public static List<Node<T>> LevelOrderTraverse(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root != null)
            {
                var q = new Queue<Node<T>>();
                q.Enqueue(root);
                while (q.Count > 0)
                {
                    var temp = q.Dequeue();
                    list.Add(temp);
                    if (temp.Left != null) q.Enqueue(temp.Left);
                    if (temp.Right != null) q.Enqueue(temp.Right);
                }
            }
            return list;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root==null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth > rightDepth) ?
                leftDepth + 1 :
                rightDepth + 1;
        }

        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null) throw new Exception("Empty tree. ");

            var q = new Queue.ArrayQueue<Node<T>>();

            q.Enqueue(root);
            while (q.Count>0)
            {
                temp = q.Dequeue();
                if (temp.Left != null)
                    q.Enqueue(temp.Left);
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
            }
            return temp;
        }

        public Node<T> DeepestNode()
        {
            var list = LevelOrderTraverse(Root);
            return list[list.Count - 1];
        }

        public static int NumberOfLeafs(Node<T> root)
        {
            //int count = 0;
            //if (root == null) return count;
            //var q = new Queue.LinkedListQueue<Node<T>>();
            //q.Enqueue(root);
            //while (q.Count>0)
            //{
            //    var temp = q.Dequeue();
            //    if (temp.Left == null && temp.Right == null)
            //        count++;
            //    if (temp.Left != null)
            //        q.Enqueue(temp.Left);
            //    if (temp.Right != null)
            //        q.Enqueue(temp.Right);
            //}
            //return count;

            return LevelOrderTraverse(root)
                .Where(x => x.Left == null && x.Right == null)
                .ToList()
                .Count();
        }

        public static int NumberOfFullNodes(Node<T> root) =>
            LevelOrderTraverse(root)
            .Where(node => node.Left != null && node.Right != null)
            .ToList()
            .Count;

        public static int NumberOfHalfNodes(Node<T> root) =>
            LevelOrderTraverse(root)
            .Where(node => (node.Left != null && node.Right == null) ||
            (node.Left == null && node.Right != null))
            .ToList()
            .Count;

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root == null)
                return;
            path[pathLen] = root.Value;
            pathLen++;

            if (root.Left==null && root.Right==null) //yaprak mı ?
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }
        }

        private void PrintArray(T[] path,int len)
        {
            for (int i = 0; i < len; i++)
                Console.Write($"{path[i]} ");
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            return LevelOrderTraverse(this.Root).GetEnumerator();
        }

        public T Delete(T value)
        {
            throw new NotImplementedException();
        }

        public T Delete()
        {
            throw new NotImplementedException();
        }
    }
}
