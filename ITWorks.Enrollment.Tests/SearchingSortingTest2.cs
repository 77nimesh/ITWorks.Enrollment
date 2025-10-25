using ITWorks.Enrollment.ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.Tests
{
    internal class SearchingSortingTest2
    {

        private Student[] students;

        [SetUp]
        public void Setup()
        {
            // 10+ Students (unordered on purpose)
            students = new Student[]
            {
           new Student{ StudentID = "105", Name = "Alice" },
           new Student{ StudentID = "202", Name = "Bob" },
           new Student{ StudentID = "150", Name = "Carol" },
           new Student{ StudentID = "301", Name = "David" },
           new Student{ StudentID = "120", Name = "Eve" },
           new Student{ StudentID = "099", Name = "Frank" },
           new Student{ StudentID = "500", Name = "Grace" },
           new Student{ StudentID = "250", Name = "Heidi" },
           new Student{ StudentID = "175", Name = "Ivan" },
           new Student{ StudentID = "400", Name = "Judy" },
            };
        }

        [Test]
        public void LinearSearch_Hit_And_Miss()
        {
            // Hit
            int posHit = Utility.LinearSearchArray(students, new Student { StudentID = "150" });
            Assert.GreaterOrEqual(posHit, 0, "Should find StudentID=150");
            Assert.AreEqual("150", students[posHit].StudentID);

            // Miss
            int posMiss = Utility.LinearSearchArray(students, new Student { StudentID = "999" });
            Assert.AreEqual(-1, posMiss, "Should not find StudentID=999");
        }

        [Test]
        public void BinarySearch_Hit_And_Miss_On_Sorted_Array()
        {
            // Must sort ascending before binary search
            Utility.SortArrayAscending(students);

            // Hit
            int posHit = Utility.BinarySearchArray(students, new Student { StudentID = "202" });
            Assert.GreaterOrEqual(posHit, 0, "Should find StudentID=202 after sorting");
            Assert.AreEqual("202", students[posHit].StudentID);

            // Miss
            int posMiss = Utility.BinarySearchArray(students, new Student { StudentID = "111" });
            Assert.AreEqual(-1, posMiss, "Should not find StudentID=111");
        }

        [Test]
        public void SelectionSort_Ascending_EntireArray_Is_Ordered()
        {
            Utility.SortArrayAscending(students);

            var ids = students.Select(s => s.StudentID).ToArray();

            // Expected (manually sorted)
            var expectedAsc = new[] { "099", "105", "120", "150", "175", "202", "250", "301", "400", "500" };

            CollectionAssert.AreEqual(expectedAsc, ids,
                "Array must be sorted ascending by StudentID (lexicographic compare).");
        }

        [Test]
        public void SelectionSort_Descending_EntireArray_Is_Ordered()
        {
            Utility.SortArrayDescending(students);

            var ids = students.Select(s => s.StudentID).ToArray();

            // Expected (manually sorted descending)
            var expectedDesc = new[] { "500", "400", "301", "250", "202", "175", "150", "120", "105", "099" };

            CollectionAssert.AreEqual(expectedDesc, ids,
                "Array must be sorted descending by StudentID (lexicographic compare).");
        }

        [Test]
        public void Negative_Check_Fails_If_Expected_Order_Is_Wrong()
        {
            Utility.SortArrayAscending(students);
            var ids = students.Select(s => s.StudentID).ToArray();

            // Intentionally wrong expected order (descending)
            var wrongExpected = new[] { "500", "400", "301", "250", "202", "175", "150", "120", "105", "099" };

            // This should fail—use Assert.AreNotEqual to *prove* your test would detect a mistake.
            Assert.AreNotEqual(string.Join(",", wrongExpected), string.Join(",", ids),
                "Swapped expected order should not match ascending sort result.");
        }

    }
}
