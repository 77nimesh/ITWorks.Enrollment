using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>Links a Student to a Subject with enrolment details.</summary>
    public class Enrollment
    {
        /// <summary>Student ID linking to Student.StudentID.</summary>
        public string StudentID { get; set; }
        /// <summary>Subject code linking to Subject.SubjectCode.</summary>
        public string SubjectCode { get; set; }
        /// <summary>Date the student enrolled in the subject.</summary>
        public DateTime DateEnrolled { get; set; }
        /// <summary>Grade received for the subject.</summary>
        public string Grade { get; set; }
        /// <summary>Semester in which the subject was taken.</summary>
        public string Semester { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enrollment"/> class with default values.
        /// </summary>
        public Enrollment() : this("", "", DateTime.MinValue, "", "") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enrollment"/> class with specified values.
        /// </summary>
        /// <param name="studentId">Student ID.</param>
        /// <param name="subjectCode">Subject code.</param>
        /// <param name="dateEnrolled">Date enrolled.</param>
        /// <param name="grade">Grade.</param>
        /// <param name="semester">Semester.</param>
        public Enrollment(string studentId, string subjectCode, DateTime dateEnrolled, string grade, string semester)
        {
            StudentID = studentId?.Trim() ?? "";
            SubjectCode = subjectCode?.Trim() ?? "";
            DateEnrolled = dateEnrolled;
            Grade = grade?.Trim() ?? "";
            Semester = semester?.Trim() ?? "";
        }

        /// <summary>
        /// Returns a string representation of the enrollment.
        /// </summary>
        /// <returns>All enrollment fields as a formatted string.</returns>
        public override string ToString() =>
            $"Enrollment: Student={StudentID}, Subject={SubjectCode}, {Semester}, Date={DateEnrolled:yyyy-MM-dd}, Grade={Grade}";
    }
}
