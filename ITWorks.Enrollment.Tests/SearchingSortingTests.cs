using ITWorks.Enrollment;
using ITWorks.Enrollment.ConsoleApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace ITWorks.Enrollment.Tests
{
    [TestFixture]
    public class SearchingSortingTests
    {
        private Student[] students;


        [SetUp]
        public void Setup()
        {
            students = new[]
            {
            new Student{ StudentID="105" }, new Student{ StudentID="202" },
            new Student{ StudentID="150" }, new Student{ StudentID="301" },
            new Student{ StudentID="120" }, new Student{ StudentID="099" },
            new Student{ StudentID="500" }, new Student{ StudentID="250" },
            new Student{ StudentID="175" }, new Student{ StudentID="400" },
        };
        }

        [TestCase("150", true)]
        [TestCase("999", false)]
        public void LinearSearch_Returns_Index_For_Hits_And_Minus1_For_Misses(string id, bool shouldFind)
        {
            int pos = Utility.LinearSearchArray(students, new Student { StudentID = id });
            if (shouldFind)
            {
                Assert.GreaterOrEqual(pos, 0);
                Assert.AreEqual(id, students[pos].StudentID);
            }
            else
            {
                Assert.AreEqual(-1, pos);
            }
        }

        [TestCase("202", true)]
        [TestCase("111", false)]
        public void BinarySearch_Requires_Sorted_Ascending(string id, bool shouldFind)
        {
            Utility.SortArrayAscending(students);
            int pos = Utility.BinarySearchArray(students, new Student { StudentID = id });

            if (shouldFind)
            {
                Assert.GreaterOrEqual(pos, 0);
                Assert.AreEqual(id, students[pos].StudentID);
            }
            else
            {
                Assert.AreEqual(-1, pos);
            }
        }

        [Test]
        public void BubbleSort_Ascending_Matches_Expected()
        {
            Utility.SortArrayAscending(students);
            var ids = students.Select(s => s.StudentID).ToArray();
            var expected = new[] { "099", "105", "120", "150", "175", "202", "250", "301", "400", "500" };
            CollectionAssert.AreEqual(expected, ids);
        }

        [Test]
        public void BubbleSort_Descending_Matches_Expected()
        {
            Utility.SortArrayDescending(students);
            var ids = students.Select(s => s.StudentID).ToArray();
            var expected = new[] { "500", "400", "301", "250", "202", "175", "150", "120", "105", "099" };
            CollectionAssert.AreEqual(expected, ids);
        }

        [Test]
        public void LinearSearch_Throws_On_Null_Array()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Utility.LinearSearchArray<Student>(null, new Student { StudentID = "100" }));
        }

    }
}
