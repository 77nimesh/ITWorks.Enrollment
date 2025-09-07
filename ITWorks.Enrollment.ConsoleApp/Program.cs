using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>
    /// Entry point for the application. Tests OO classes constructors and standard methods. 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method to run the application and test classes.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            var addr = new Address("1", "North Tce", "Adelaide", "5000", "SA");

            var s1 = new Student("A00123", "Nimesh G", "nimesh@example.com", "0400 000 000", addr, new DateTime(1994, 1, 10)) { Program = "ICT" };
            var s2 = new Student("a00123", "Nimesh Gamage", "nimesh@example.com", "0400 111 111", addr, new DateTime(1994, 1, 11)) { Program = "ICT" };
            var s3 = new Student("B00999", "Christy R", "Christy@example.com", "0400 222 222", new Address(), new DateTime(1994, 1, 12)) { Program = "WEB" };

            Console.WriteLine("== Part 1: Equality & Hashing ==");
            Console.WriteLine($"s1 == s2? {s1 == s2}  (expect True)");
            Console.WriteLine($"s1.Equals(s2)? {s1.Equals(s2)}  (expect True)");
            Console.WriteLine($"s1 == s3? {s1 == s3}  (expect False)\n");

            Console.WriteLine("Hash codes:");
            Console.WriteLine($"s1: {s1.GetHashCode()}");
            Console.WriteLine($"s2: {s2.GetHashCode()}  (expect same as s1)");
            Console.WriteLine($"s3: {s3.GetHashCode()}\n");

            var set = new HashSet<Student> { s1 };
            set.Add(s2); // no new item (same StudentID)
            set.Add(s3);
            Console.WriteLine($"HashSet count (expect 2): {set.Count}\n");

            var sub = new Subject("ICTPRG547", "Apply advanced programming skills in another language", 0m);
            var enr = new Enrollment(s1.StudentID, sub.SubjectCode, DateTime.Today, "SA", "S2");
            Console.WriteLine(addr);
            Console.WriteLine(sub);
            Console.WriteLine(enr+"\n");

            var grades = new Dictionary<Student, string> { { s1, "NS" } };
            grades[s2] = "SA"; // overwrites s1 (same key by StudentID)
            grades[s3] = "CN";
            Console.WriteLine($"Grade for s1 (expect SA): {grades[s1]}");
            Console.WriteLine($"Lookup by s2 (expect SA): {grades[s2]}");
            Console.WriteLine($"Grade for s3 (expect CN): {grades[s3]}");


            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
