using System;

namespace ITWorks.Enrollment.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t------- Initial Stage — Create Classes (Session 1 style) --------\n");

            Address addr = new Address();
            Console.WriteLine("[Default Address] " + addr + "\n");
            addr = new Address("1", "North Tce", "Adelaide", "5000", "sa");
            Console.WriteLine("[Address all-arg] " + addr + "\n");

            Person per = new Person();
            Console.WriteLine("[Default Person] " + per + "\n");
            per = new Person("Nimesh", "nimesh@example.com", "04123 456 789", addr);
            Console.WriteLine("[Person all-arg] " + per + "\n");

            Subject sub = new Subject();
            Console.WriteLine("[Default Subject] " + sub + "\n");
            sub = new Subject("ICTPRG547", "Apply advanced programming skills", 0m);
            Console.WriteLine("[Subject all-arg] " + sub + "\n");

            Enrolment enr = new Enrolment();
            Console.WriteLine("[Default Enrolmant]" + enr + "\n");
            enr = new Enrolment(sub, DateTime.Today, "SA", "S2-2025");
            Console.WriteLine("[Enrolment all-arg] " + enr + "\n");

            Student stu = new Student();
            Console.WriteLine("[Default Student] " + stu + "\n");
            stu = new Student("A00123", "Nimesh G", "nimesh@example.com", "0400 000 000", addr, new DateTime(2025, 1, 10), "ICT");
            Console.WriteLine("[Student all-agr] " + stu + "\n");

            Student stu1 = new Student("A00134", per, new DateTime(2025, 10, 25), "IT");
            Console.WriteLine("[Student with Person obj] " + stu1 + "\n");

            // ---------- Part 1: Hashing tests ----------
            Console.WriteLine("\n\t\t------------ Part 1: Hashing (Equality & GetHashCode) -------------\n");

            var sA = new Student("A00123", "Nimesh G", "nimesh@example.com", "0400 000 000", addr, new DateTime(1994, 1, 10), "ICT");
            var sB = new Student("a00123", "Nimesh Gamage", "nimesh@example.com", "0400 111 111", addr, new DateTime(1994, 1, 11), "ICT");
            var sC = new Student("B00999", "Christy R", "Christy@example.com", "0400 222 222", new Address(), new DateTime(1994, 1, 12), "WEB");
            Console.WriteLine("[Test Data Samples]\n");
            Console.WriteLine("sA : " + sA);
            Console.WriteLine("sB : " + sB);
            Console.WriteLine("sC : " + sC);
            Console.WriteLine("\n[Results]");



            Console.WriteLine("Equals(sA, sB)         : " + sA.Equals(sB));           // True (same ID)
            Console.WriteLine("sA == sB               : " + (sA == sB));              // True
            Console.WriteLine("sA != sC               : " + (sA != sC));              // True (different ID)
            Console.WriteLine("Hash(sA) == Hash(sB)   : " + (sA.GetHashCode() == sB.GetHashCode())); // True

            // HashSet should keep only unique logical Students (by ID)
            var set = new System.Collections.Generic.HashSet<Student>();
            set.Add(sA);
            set.Add(sB); // duplicate ID – should not increase count
            set.Add(sC);
            Console.WriteLine("HashSet Count (expect 2): " + set.Count);

            // Dictionary lookup by key: using Student as key or using StudentID string
            var dict = new System.Collections.Generic.Dictionary<Student, string>();
            dict[sA] = "First record";
            dict[sB] = "Overwrites same-ID"; // same key by equality/hashing
            dict[sC] = "Another record";
            Console.WriteLine("Dictionary Count (expect 2): " + dict.Count);
            Console.WriteLine("Dictionary[sA]: " + dict[sA]); // "Overwrites same-ID"

            Console.WriteLine("\n\n\t-------------Testing DataStructure---------------\n");

            DSAtest.DemoSinglyLinkedList();
            Console.WriteLine("\n");
            DSAtest.DemoDoublyLinkedList();
            Console.WriteLine();
            Console.WriteLine("\n\t-------------Testing Binary Search Tree---------------\n");
            BSTTest.BST_WithStudents();

            Console.WriteLine("\nAll constructors and ToString() executed. Press any key...");

        }
    }
}
