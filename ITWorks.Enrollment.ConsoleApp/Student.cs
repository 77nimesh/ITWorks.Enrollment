using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>Student inherits Person. Equality &amp; hashing by StudentID (case-insensitive).</summary>
    public class Student : Person, IEquatable<Student>
    {
        /// <summary>Default student ID constant.</summary>
        public const string DEFAULT_STUDENT_ID = "UNKNOWN";

        /// <summary>Unique student ID.</summary>
        public string StudentID { get; set; }
        /// <summary>Program enrolled by the student.</summary>
        public string Program { get; set; }
        /// <summary>Date the student registered.</summary>
        public DateTime DateRegistered { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class with default values.
        /// </summary>
        public Student()
            : this(DEFAULT_STUDENT_ID, "John Doe", "", "", new Address(), DateTime.MinValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class with specified values.
        /// </summary>
        /// <param name="studentId">Student ID.</param>
        /// <param name="name">Full name.</param>
        /// <param name="email">Email address.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="address">Postal address.</param>
        /// <param name="dateRegistered">Date registered.</param>
        public Student(string studentId, string name, string email, string phone, Address address, DateTime dateRegistered)
            : base(name, email, phone, address)
        {
            StudentID = (studentId ?? "").Trim();
            Program = "";
            DateRegistered = dateRegistered;
        }

        /// <summary>
        /// Determines whether the specified student is equal to the current student (by StudentID).
        /// </summary>
        /// <param name="other">Other student to compare.</param>
        /// <returns>True if StudentID matches (case-insensitive); otherwise, false.</returns>
        public bool Equals(Student other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(StudentID, other.StudentID, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current student.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if equal; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Student);

        /// <summary>
        /// Gets the hash code for the student (by StudentID, case-insensitive).
        /// </summary>
        /// <returns>Hash code for StudentID.</returns>
        public override int GetHashCode() =>
            StringComparer.OrdinalIgnoreCase.GetHashCode(StudentID ?? string.Empty);

        /// <summary>
        /// Equality operator for students.
        /// </summary>
        /// <param name="left">Left student.</param>
        /// <param name="right">Right student.</param>
        /// <returns>True if equal; otherwise, false.</returns>
        public static bool operator ==(Student left, Student right) => Equals(left, right);
        /// <summary>
        /// Inequality operator for students.
        /// </summary>
        /// <param name="left">Left student.</param>
        /// <param name="right">Right student.</param>
        /// <returns>True if not equal; otherwise, false.</returns>
        public static bool operator !=(Student left, Student right) => !Equals(left, right);

        /// <summary>
        /// Returns a string representation of the student.
        /// </summary>
        /// <returns>All student fields as a formatted string.</returns>
        public override string ToString() =>
            $"StudentID={StudentID}, {base.ToString()}, Program={Program}, DateRegistered={DateRegistered:yyyy-MM-dd}";
    }
}
