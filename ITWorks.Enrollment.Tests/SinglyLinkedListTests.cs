using DataStructures;
using ITWorks.Enrollment.ConsoleApp;
using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ITWorks.Enrollment.Tests
{
    [TestFixture]
    public class SinglyLinkedListTests
    {
        [Test]
        public void AddFirst_Then_AddLast_Order_Is_Correct()
        {
            var list = new SinglyLinkedList<Student>();
            list.AddFirst(new Student { StudentID = "200" }); // [200]
            list.AddFirst(new Student { StudentID = "100" }); // [100,200]
            list.AddLast(new Student { StudentID = "300" });  // [100,200,300]
            list.AddLast(new Student { StudentID = "400" });  // [100,200,300,400]

            var ids = new List<string>();
            foreach (var s in list) ids.Add(s.StudentID);
            CollectionAssert.AreEqual(new[] { "100", "200", "300", "400" }, ids);
        }

        [Test]
        public void RemoveFirst_And_RemoveLast_Work()
        {
            var list = new SinglyLinkedList<Student>();
            list.AddLast(new Student { StudentID = "100" });
            list.AddLast(new Student { StudentID = "200" });
            list.AddLast(new Student { StudentID = "300" });

            var head = list.RemoveFirst(); // 100
            Assert.AreEqual("100", head.StudentID);

            var tail = list.RemoveLast(); // 300 (O(n) by spec)
            Assert.AreEqual("300", tail.StudentID);

            var ids = new List<string>();
            foreach (var s in list) ids.Add(s.StudentID);
            CollectionAssert.AreEqual(new[] { "200" }, ids);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Remove_By_Value_Removes_First_Occurrence_Only()
        {
            var list = new SinglyLinkedList<Student>();
            var a = new Student { StudentID = "200" };
            var b = new Student { StudentID = "200" }; // duplicate by ID
            list.AddLast(new Student { StudentID = "100" });
            list.AddLast(a);
            list.AddLast(b);
            list.AddLast(new Student { StudentID = "300" });

            Assert.IsTrue(list.Remove(a)); // removes first 200
            Assert.IsTrue(list.Contains(b)); // second 200 remains
            Assert.IsFalse(list.Remove(new Student { StudentID = "999" })); // not present

            var ids = new List<string>();
            foreach (var s in list) ids.Add(s.StudentID);
            CollectionAssert.AreEqual(new[] { "100", "200", "300" }, ids);
        }

        [Test]
        public void Contains_CopyTo_Clear_Work()
        {
            var list = new SinglyLinkedList<Student>();
            list.AddLast(new Student { StudentID = "100" });
            list.AddLast(new Student { StudentID = "200" });

            Assert.IsTrue(list.Contains(new Student { StudentID = "100" }));
            Assert.IsFalse(list.Contains(new Student { StudentID = "999" }));

            var arr = new Student[list.Count];
            list.CopyTo(arr, 0);
            CollectionAssert.AreEqual(new[] { "100", "200" }, arr.Select(s => s.StudentID).ToArray());

            list.Clear();
            Assert.AreEqual(0, list.Count);
            var all = new List<Student>(); foreach (var s in list) all.Add(s);
            Assert.AreEqual(0, all.Count);
        }
    }
}
