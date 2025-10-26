using DataStructures;
using ITWorks.Enrollment.ConsoleApp;
using DataStructures;
using NUnit.Framework;
using System.Linq;

namespace ITWorks.Enrollment.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void InOrder_Is_Sorted_For_Classic_Seven_Node_Tree()
        {
            var bst = new BinarySearchTree();
            int[] keys = { 4, 2, 1, 3, 6, 5, 7 };
            foreach (var k in keys) bst.Add(k);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, bst.ToInOrderArray());
            Assert.AreEqual(3, bst.GetTreeDepth()); // balanced
        }

        [Test]
        public void Remove_Leaf_OneChild_TwoChildren()
        {
            var bst = new BinarySearchTree();
            int[] keys = { 50, 30, 70, 20, 40, 60, 80, 45, 75 };
            foreach (var k in keys) bst.Add(k);

            // leaf
            bst.Remove(75);
            Assert.IsNull(bst.Find(75));

            // one child (40 has right child 45)
            bst.Remove(40);
            Assert.IsNull(bst.Find(40));
            Assert.IsNotNull(bst.Find(45));

            // two children (50)
            bst.Remove(50);
            Assert.IsNull(bst.Find(50));

            var expected = keys.Except(new[] { 75, 40, 50 }).OrderBy(x => x).ToArray();
            CollectionAssert.AreEqual(expected, bst.ToInOrderArray());
        }

        // -------- Variant: test with Students via numeric StudentID --------

        private static int Key(Student s) { return int.Parse(s.StudentID); }

        [Test]
        public void InOrder_With_Students_Matches_Ids_Sorted_Numerically()
        {
            var bst = new BinarySearchTree();
            var students = new[]
            {
                new Student { StudentID = "105" }, new Student { StudentID = "202" },
                new Student { StudentID = "150" }, new Student { StudentID = "301" },
                new Student { StudentID = "120" }, new Student { StudentID = "099" },
                new Student { StudentID = "500" }, new Student { StudentID = "250" },
                new Student { StudentID = "175" }, new Student { StudentID = "400" },
            };

            foreach (var s in students) bst.Add(Key(s));

            var expected = students.Select(Key).OrderBy(x => x).ToArray();
            CollectionAssert.AreEqual(expected, bst.ToInOrderArray());
        }
    }
}
