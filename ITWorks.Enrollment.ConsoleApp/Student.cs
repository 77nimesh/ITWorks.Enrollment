using System;

namespace ITWorks.Enrollment.ConsoleApp
{
    public class Student : Person, IComparable<Student>
    {
        public const string DEF_ID = "A00000";
        public const string DEF_PROGRAM = "GEN";
        public static readonly DateTime DEF_DOB = DateTime.MinValue;

        public string StudentID { get; set; }
        public string Program { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Student has an Enrolment (from initial stage feedback)
        public Enrolment Enrolment { get; set; }

        public Student() : this(DEF_ID, DEF_NAME, DEF_EMAIL, DEF_PHONE, new Address(), DEF_DOB, DEF_PROGRAM) { }

        public Student(string studentId, string name, string email, string phone, Address address, DateTime dob, string program)
            : base(name, email, phone, address)
        {
            StudentID = studentId;
            DateOfBirth = dob;
            Program = program;
        }

        /// <summary>
        /// Determines logical equality of Student objects.
        /// Two Students are considered equal if their <see cref="StudentID"/> values are equal.
        /// </summary>
        /// <param name="obj">Another object to compare with this instance.</param>
        /// <returns>true if obj is a Student with the same StudentID; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Student other)
                return string.Equals(this.StudentID, other.StudentID, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        /// <summary>
        /// Returns a hash code that is consistent with <see cref="Equals(object)"/>.
        /// Students that are equal by <see cref="StudentID"/> produce the same hash code.
        /// </summary>
        /// <remarks>
        /// This enables efficient use in hash-based collections (e.g., Dictionary, HashSet).
        /// </remarks>
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(StudentID ?? string.Empty);
        }

        /// <summary>
        /// Equality operator delegates to <see cref="Equals(object)"/>.
        /// </summary>
        public static bool operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator delegates to <see cref="Equals(object)"/>.
        /// </summary>
        public static bool operator !=(Student a, Student b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Compares Students by <see cref="StudentID"/> to support ordering if required later.
        /// </summary>
        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return string.Compare(this.StudentID, other.StudentID, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return "StudentID: " + StudentID + ", Name: " + Name + ", Email: " + Email
                 + ", Program: " + Program + ", Address: [" + Address + "]";
        }
    }
}
