using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Surname cannot be null or empty.");
                }
                _surname = value;
            }
        }

        private PhoneNumber _phoneNumber;
        public PhoneNumber PhoneNumber
        {
            get { return _phoneNumber; }
            private set
            {
                _phoneNumber = value;
            }
        }

        

        public Adopter(string name, string surname, PhoneNumber phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }
    }
}
