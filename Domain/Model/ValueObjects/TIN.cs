using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record TIN
    {
        const string consonants = "BCDFGHJKLMNPQRSTVWXYZ";
        public string Value;
        public TIN(string value)
        {
            if(value.Length != 16) throw new ArgumentException("Invalid TIN lenght");
            for(int i = 0; i < 6; i++)
            {
                if (!consonants.Contains(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            for(int i = 6; i < 8;  i++)
            {
                if(!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[8])) throw new ArgumentException("Invalid TIN format");
            for (int i = 9; i < 11; i++)
            {
                if (!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[11])) throw new ArgumentException("Invalid TIN format");
            for(int i = 12;  i < 15; i++)
            {
                if (!Char.IsDigit(value[i])) throw new ArgumentException("Invalid TIN format");
            }
            if (!Char.IsLetter(value[15])) throw new ArgumentException("Invalid TIN format");

            Value = value;
        }
    }
}
