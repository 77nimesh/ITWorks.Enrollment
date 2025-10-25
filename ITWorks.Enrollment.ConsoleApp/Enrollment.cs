using System;

namespace ITWorks.Enrollment.ConsoleApp
{
    public class Enrolment
    {
        public const string DEF_TERM = "T1-2025";
        public static readonly DateTime DEF_DATE = DateTime.MinValue;
        public const string DEF_GRADE = "NA";


        public Subject Subject { get; set; }

        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public string Term { get; set; }

        public Enrolment() : this(new Subject(), DEF_DATE, DEF_GRADE, DEF_TERM) { }

        public Enrolment(Subject subject, DateTime dateEnrolled, string grade, string term)
        {

            Subject = subject;
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Term = term;
        }

        public override string ToString()
        {
            return "Enrolment -> Subject: " + (Subject != null ? Subject.ToString() : "null")
                 + ", Term: " + Term + ", Date: " + DateEnrolled.ToString("yyyy-MM-dd")
                 + ", Grade: " + Grade;
        }
    }
}
