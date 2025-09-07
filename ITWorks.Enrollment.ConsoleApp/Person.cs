using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>Base entity for people in the system.</summary>
    public class Person
    {
        /// <summary>Full name of the person.</summary>
        public string Name { get; set; }
        /// <summary>Email address of the person.</summary>
        public string Email { get; set; }
        /// <summary>Phone number of the person.</summary>
        public string PhoneNumber { get; set; }
        /// <summary>Postal address of the person.</summary>
        public Address Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with default values.
        /// </summary>
        public Person() : this("John Doe", "", "", new Address()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with specified values.
        /// </summary>
        /// <param name="name">Full name.</param>
        /// <param name="email">Email address.</param>
        /// <param name="phoneNumber">Phone number.</param>
        /// <param name="address">Postal address.</param>
        public Person(string name, string email, string phoneNumber, Address address)
        {
            Name = name?.Trim() ?? "";
            Email = email?.Trim() ?? "";
            PhoneNumber = phoneNumber?.Trim() ?? "";
            Address = address ?? new Address();
        }

        /// <summary>
        /// Returns a string representation of the person.
        /// </summary>
        /// <returns>All person fields as a formatted string.</returns>
        public override string ToString() =>
            $"Name={Name}, Email={Email}, Phone={PhoneNumber}, Address=({Address})";
    }
}
