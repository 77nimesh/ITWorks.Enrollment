using DataStructures;
using ITWorks.Enrollment.ConsoleApp;
using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ITWorks.Enrollment.Tests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        [Test]
        public void AddFirst_AddLast_Bidirectional_Order()
        {
            var list = new DoublyLinkedList<Student>();
            list.AddFirst(new Student { StudentID = "200" }); // [200]
            list.AddFirst(new Student { StudentID = "100" }); // [100,200]
            list.AddLast(new Student { StudentID = "300" });  // [100,200,300]
            list.AddLast(new Student { StudentID = "400" });  // [100,200,300,400]

            // Forward walk
            var fwd = new List<string>();
            var n = list.Head;
            while (n != null) { fwd.Add(n.Value.StudentID); n = n.Next; }
            CollectionAssert.AreEqual(new[] { "100", "200", "300", "400" }, fwd);

            // Backward walk
            var back = new List<string>();
            n = list.Tail;
            while (n != null) { back.Add(n.Value.StudentID); n = n.Previous; }
            CollectionAssert.AreEqual(new[] { "400", "300", "200", "100" }, back);
        }

        [Test]
        public void RemoveFirst_RemoveLast()
        {
            var list = new DoublyLinkedList<Student>();
            list.AddLast(new Student { StudentID = "100" });
            list.AddLast(new Student { StudentID = "200" });
            list.AddLast(new Student { StudentID = "300" });

            var first = list.RemoveFirst(); // 100
            Assert.AreEqual("100", first.StudentID);

            var last = list.RemoveLast(); // 300
            Assert.AreEqual("300", last.StudentID);

            // Forward remains only 200
            var fwd = new List<string>();
            var n = list.Head;
            while (n != null) { fwd.Add(n.Value.StudentID); n = n.Next; }
            CollectionAssert.AreEqual(new[] { "200" }, fwd);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Remove_By_Value_Head_Middle_Tail()
        {
            var list = new DoublyLinkedList<Student>();
            var a = new Student { StudentID = "100" };
            var b = new Student { StudentID = "200" };
            var c = new Student { StudentID = "300" };
            list.AddLast(a);
            list.AddLast(b);
            list.AddLast(c);

            Assert.IsTrue(list.Remove(a)); // head
            Assert.IsTrue(list.Remove(b)); // middle (now head==c)
            Assert.IsTrue(list.Remove(c)); // tail (last)
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Remove(new Student { StudentID = "999" }));
        }

        [Test]
        public void Contains_CopyTo()
        {
            var list = new DoublyLinkedList<Student>();
            list.AddLast(new Student { StudentID = "100" });
            list.AddLast(new Student { StudentID = "200" });

            Assert.IsTrue(list.Contains(new Student { StudentID = "100" }));
            Assert.IsFalse(list.Contains(new Student { StudentID = "999" }));

            var arr = new Student[list.Count];
            list.CopyTo(arr, 0);
            CollectionAssert.AreEqual(new[] { "100", "200" }, arr.Select(s => s.StudentID).ToArray());

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
    }
}
