using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>Subject offered for enrolment. </summary>
    public class Subject
    {
        /// <summary>Unique code for the subject.</summary>
        public string SubjectCode { get; set; }
        /// <summary>Name of the subject.</summary>
        public string SubjectName { get; set; }
        /// <summary>Cost of the subject.</summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class with default values.
        /// </summary>
        public Subject() : this("UNKN000", "Untitled Subject", 0m) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class with specified values.
        /// </summary>
        /// <param name="subjectCode">Subject code.</param>
        /// <param name="subjectName">Subject name.</param>
        /// <param name="cost">Cost of the subject.</param>
        public Subject(string subjectCode, string subjectName, decimal cost)
        {
            SubjectCode = subjectCode?.Trim() ?? "";
            SubjectName = subjectName?.Trim() ?? "";
            Cost = cost < 0 ? 0 : cost;
        }

        /// <summary>
        /// Returns a string representation of the subject.
        /// </summary>
        /// <returns>All subject fields as a formatted string.</returns>
        public override string ToString() => $"{SubjectCode} - {SubjectName} (${Cost:0.00})";
    }
}
