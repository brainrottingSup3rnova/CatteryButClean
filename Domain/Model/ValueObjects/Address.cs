using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Address
    {
        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Street cannot be null or empty.");
                }
                _street = value;
            }
        }
        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be null or empty.");
                }
                _city = value;
            }
        }
        private string _postalCode;
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Postal Code cannot be null or empty.");
                }
                _postalCode = value;
            }
        }

        public Address(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }
    }
}
