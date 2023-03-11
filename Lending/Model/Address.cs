using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending.Model
{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address(string Street, string HouseNumber, string PostalCode, string City)
        {
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.PostalCode = PostalCode;
            this.City = City;
        }

        public Address() { }
    }
}
