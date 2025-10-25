namespace ITWorks.Enrollment.ConsoleApp
{
    public class Subject
    {
        public const string DEF_CODE = "UNKN000";
        public const string DEF_NAME = "Untitled Subject";
        public const decimal DEF_COST = 0m;

        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public decimal Cost { get; set; }

        public Subject() : this(DEF_CODE, DEF_NAME, DEF_COST) { }

        public Subject(string subjectCode, string subjectName, decimal cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Cost = (cost < 0) ? 0 : cost;
        }

        public override string ToString()
        {
            return "Subject Code: " + SubjectCode + " Subject Name: " + SubjectName + " Subject cost $" + Cost.ToString("0.00");
        }
    }
}
