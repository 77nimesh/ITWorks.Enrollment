using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;


namespace ITWorks.Enrollment.ConsoleApp
{
    class DSAtest
    {

        // ------------------------------------------------------------
        // DEMO: Singly Linked List 
        // ------------------------------------------------------------
        public static void DemoSinglyLinkedList()
        {
            Console.WriteLine("---- SinglyLinkedList<T> Demo ----");

            var list = new SinglyLinkedList<Student>();

            // AddFirst / AddLast (value overloads)
            list.AddFirst(new Student { StudentID = "200", Name = "B" }); // [200]
            list.AddFirst(new Student { StudentID = "100", Name = "A" }); // [100,200]
            list.AddLast(new Student { StudentID = "300", Name = "C" });  // [100,200,300]
            list.AddLast(new Student { StudentID = "400", Name = "D" });  // [100,200,300,400]

            PrintSingly(list, "After AddFirst/AddLast");

            // Contains / Index lookup demo (via simple LINQ)
            var target = new Student { StudentID = "300" };
            Console.WriteLine("Contains 300? " + list.Contains(target));
            Console.WriteLine("Index of 300? " + list.IndexOf(target));

            // RemoveFirst / RemoveLast
            var removedHead = list.RemoveFirst(); // remove 100
            Console.WriteLine("Removed Head: " + removedHead.StudentID);
            var removedTail = list.RemoveLast();  // remove 400
            Console.WriteLine("Removed Tail: " + removedTail.StudentID);
            PrintSingly(list, "After RemoveFirst/RemoveLast");

            // Remove(item) – first occurrence
            var toRemove = new Student { StudentID = "200" };
            Console.WriteLine("Remove 200? " + list.Remove(toRemove));
            PrintSingly(list, "After Remove(200)");

            // CopyTo
            var array = new Student[list.Count];
            list.CopyTo(array, 0);
            Console.WriteLine("CopyTo array: " + string.Join(", ", array.Select(s => s.StudentID)));

            // Clear
            list.Clear();
            Console.WriteLine("Cleared list. Count=" + list.Count);
        }

        private static void PrintSingly(SinglyLinkedList<Student> list, string title)
        {
            Console.Write(title + "  ->  ");
            bool first = true;
            foreach (var s in list)
            {
                if (!first) Console.Write(" -> ");
                Console.Write(s.StudentID);
                first = false;
            }
            if (first) Console.Write("(empty)");
            Console.WriteLine();
        }

        // ------------------------------------------------------------
        // DEMO: Doubly Linked List 
        // ------------------------------------------------------------
        public static void DemoDoublyLinkedList()
        {
            Console.WriteLine("---- DoublyLinkedList<T> Demo ----");

            var list = new DoublyLinkedList<Student>();

            // AddFirst / AddLast (value overloads)
            list.AddFirst(new Student { StudentID = "200", Name = "B" }); // [200]
            list.AddFirst(new Student { StudentID = "100", Name = "A" }); // [100,200]
            list.AddLast(new Student { StudentID = "300", Name = "C" });  // [100,200,300]
            list.AddLast(new Student { StudentID = "400", Name = "D" });  // [100,200,300,400]

            PrintDoublyForward(list, "After AddFirst/AddLast (forward)");
            PrintDoublyBackward(list, "After AddFirst/AddLast (backward)");

            // Contains
            Console.WriteLine("Contains 300? " + list.Contains(new Student { StudentID = "300" }));

            // RemoveFirst / RemoveLast (O(1))
            var first = list.RemoveFirst(); // remove 100
            Console.WriteLine("Removed First: " + first.StudentID);
            var last = list.RemoveLast();   // remove 400
            Console.WriteLine("Removed Last: " + last.StudentID);
            PrintDoublyForward(list, "After RemoveFirst/RemoveLast (forward)");
            PrintDoublyBackward(list, "After RemoveFirst/RemoveLast (backward)");

            // Remove(item) – head/middle/tail case
            Console.WriteLine("Remove 200? " + list.Remove(new Student { StudentID = "200" })); // removes head now
            Console.WriteLine("Remove 999? " + list.Remove(new Student { StudentID = "999" })); // not present
            PrintDoublyForward(list, "After Remove(200), Remove(999) (forward)");
            PrintDoublyBackward(list, "After Remove(200), Remove(999) (backward)");

            // Clear
            list.Clear();
            Console.WriteLine("Cleared list. Count=" + list.Count);
        }

        private static void PrintDoublyForward(DoublyLinkedList<Student> list, string title)
        {
            Console.Write(title + "  ->  ");
            var n = list.Head;
            if (n == null) { Console.WriteLine("(empty)"); return; }
            while (n != null)
            {
                Console.Write(n.Value.StudentID);
                if (n.Next != null) Console.Write(" <-> ");
                n = n.Next;
            }
            Console.WriteLine();
        }

        private static void PrintDoublyBackward(DoublyLinkedList<Student> list, string title)
        {
            Console.Write(title + "  ->  ");
            var n = list.Tail;
            if (n == null) { Console.WriteLine("(empty)"); return; }
            while (n != null)
            {
                Console.Write(n.Value.StudentID);
                if (n.Previous != null) Console.Write(" <-> ");
                n = n.Previous;
            }
            Console.WriteLine();
        }

    }
}
