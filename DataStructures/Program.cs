using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {

          
            Console.WriteLine("\n\n ----------Demo Test Binary Search Tree ----------\n");

            var bst = new BinarySearchTree();
            // Build a balanced tree
            int[] values = { 4, 2, 1, 3, 6, 5, 7 };
            foreach (var v in values) bst.Add(v);

            Console.Write("InOrder:   ");
            bst.TraverseInOrder(x => Console.Write(x + " "));   // 1 2 3 4 5 6 7
            Console.WriteLine();

            Console.Write("PreOrder:  ");
            bst.TraversePreOrder(x => Console.Write(x + " "));  // 4 2 1 3 6 5 7
            Console.WriteLine();

            Console.Write("PostOrder: ");
            bst.TraversePostOrder(x => Console.Write(x + " ")); // 1 3 2 5 7 6 4
            Console.WriteLine();

            Console.WriteLine("Depth: " + bst.GetTreeDepth());  // 3 for this balanced tree

            
        }

        
    }
}
