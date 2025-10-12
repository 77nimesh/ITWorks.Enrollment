namespace ITWorks.Enrollment.ConsoleApp
{
    public class Address
    {
        public const string DEF_STREETNUM = "0";
        public const string DEF_STREETNAME = "No Street";
        public const string DEF_SUBURB = "No Suburb";
        public const string DEF_POSTCODE = "0000";
        public const string DEF_STATE = "SA";

        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }

        public Address() : this(DEF_STREETNUM, DEF_STREETNAME, DEF_SUBURB, DEF_POSTCODE, DEF_STATE) { }

        public Address(string streetNum, string streetName, string suburb, string postcode, string state)
        {
            StreetNum = streetNum;
            StreetName = streetName;
            Suburb = suburb;
            Postcode = postcode;
            State = state;
        }

        public override string ToString()
        {
            return StreetNum + " " + StreetName + ", " + Suburb + " " + State + " " + Postcode;
        }
    }
}
