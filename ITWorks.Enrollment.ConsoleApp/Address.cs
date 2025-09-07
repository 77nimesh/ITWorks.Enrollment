using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.Enrollment.ConsoleApp
{
    /// <summary>Postal address (value object).</summary>
    public class Address
    {
        /// <summary>Street number of the address.</summary>
        public string StreetNum { get; set; }
        /// <summary>Street name of the address.</summary>
        public string StreetName { get; set; }
        /// <summary>Suburb of the address.</summary>
        public string Suburb { get; set; }
        /// <summary>Postcode of the address. String to keep leading zeros.</summary>
        public string Postcode { get; set; }
        /// <summary>State of the address.</summary>
        public string State { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with default values.
        /// </summary>
        public Address() : this("", "", "", "", "") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with specified values.
        /// </summary>
        /// <param name="streetNum">Street number.</param>
        /// <param name="streetName">Street name.</param>
        /// <param name="suburb">Suburb.</param>
        /// <param name="postcode">Postcode.</param>
        /// <param name="state">State.</param>
        public Address(string streetNum, string streetName, string suburb, string postcode, string state)
        {
            StreetNum = streetNum?.Trim() ?? "";
            StreetName = streetName?.Trim() ?? "";
            Suburb = suburb?.Trim() ?? "";
            Postcode = postcode?.Trim() ?? "";
            State = state?.Trim() ?? "";
        }

        /// <summary>
        /// Returns a string representation of the address.
        /// </summary>
        /// <returns>All address fields as a formatted string.</returns>
        public override string ToString() =>
            $"{StreetNum} {StreetName}, {Suburb} {State} {Postcode}";
    }
}
