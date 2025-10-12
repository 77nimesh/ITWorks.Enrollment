namespace ITWorks.Enrollment.ConsoleApp
{
    public class Person
    {
        public const string DEF_NAME = "No Name";
        public const string DEF_EMAIL = "no@email.com";
        public const string DEF_PHONE = "0000 000 000";

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public Person() : this(DEF_NAME, DEF_EMAIL, DEF_PHONE, new Address()) { }

        public Person(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString()
        {
            return "Name=" + Name + ", Email=" + Email + ", Phone=" + PhoneNumber + ", Address=(" + Address + ")";
        }
    }
}
