using System;

namespace Divido.Net.Sdk.Models.CreditRequest
{
    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Address Address { get; set; }

        public Address ShippingAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}