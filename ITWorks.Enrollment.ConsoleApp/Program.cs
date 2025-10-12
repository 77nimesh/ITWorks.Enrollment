using System;

namespace ITWorks.Enrollment.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Initial Stage — Create Classes (Session 1 style) ===\n");

            var addr = new Address("1", "North Tce", "Adelaide", "5000", "SA");
            Console.WriteLine("[Address] " + addr);

            var sub = new Subject("ICTPRG547", "Apply advanced programming skills", 0m);
            Console.WriteLine("[Subject] " + sub);

            var stu = new Student("A00123", "Nimesh G", "nimesh@example.com", "0400 000 000", addr, new DateTime(1994, 1, 10), "ICT");
            Console.WriteLine("[Student] " + stu);

            var enr = new Enrolment(stu, sub, DateTime.Today, "SA", "S2-2025");
            stu.Enrolment = enr;

            Console.WriteLine("[Enrolment] " + enr);

            // ---------- Part 1: Hashing tests ----------
            Console.WriteLine("\n=== Part 1: Hashing (Equality & GetHashCode) ===");

            var sA = new Student("A00123", "Nimesh G", "nimesh@example.com", "0400 000 000", addr, new DateTime(1994, 1, 10), "ICT");
            var sB = new Student("a00123", "Nimesh Gamage", "nimesh@example.com", "0400 111 111", addr, new DateTime(1994, 1, 11), "ICT");
            var sC = new Student("B00999", "Christy R", "Christy@example.com", "0400 222 222", new Address(), new DateTime(1994, 1, 12), "WEB");


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


            Console.WriteLine("\nAll constructors and ToString() executed. Press any key...");
            Console.ReadKey();
        }
    }
}
