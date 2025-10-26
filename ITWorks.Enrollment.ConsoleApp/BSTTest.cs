using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    class BSTTest
    {
        private static int Key(Student s) => int.Parse(s.StudentID);
        public static void BST_WithStudents()
        {
            Console.WriteLine("---- BST with Students (keys = numeric StudentID) ----");
            var bst = new BinarySearchTree();

            var students = new[]
            {
            new Student { StudentID = "105", Name = "Alice" },
            new Student { StudentID = "202", Name = "Bob" },
            new Student { StudentID = "150", Name = "Carol" },
            new Student { StudentID = "120", Name = "Eve" },
            };

            foreach (var s in students) bst.Add(Key(s));

            Console.Write("PreOrder: ");
            bst.TraversePreOrder(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.Write("InOrder: ");
            bst.TraverseInOrder(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.Write("PostOrder: ");
            bst.TraversePostOrder(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.WriteLine("Find 150? " + (bst.Find(150) != null));
            bst.Remove(150);
            Console.WriteLine("After Remove(150), Find 150? " + (bst.Find(150) != null));
        }



    }
}
