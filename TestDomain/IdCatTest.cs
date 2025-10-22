using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;
using Domain.Model.Entities;

namespace TestDomain
{
    public sealed class IdCatTest
    {
        [TestMethod]
        public void IdCat_WithValidValue_UpdateIdCat()
        {
            Cat cat = new Cat("Minù", "Ragdoll", false, new DateTime(13, 07, 2009, 6,8,5), null, new DateTime(13, 07, 2009, 6, 8, 5), null );
            List<string> months = new List<string> { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };

            string idcat = cat.Id.Value;

            if(idcat.Length != 13) throw new ArgumentException("invalid Id");
            for (int i = 0; i < 5; i++) 
            {
                if (!Char.IsDigit(idcat[i]))
                {
                    throw new ArgumentException("invalid Id");
                }
            }
            if (!months.Contains(idcat[5].ToString()))
            {
                throw new ArgumentException("invalid Id");
            }
            for(int i = 6; i < 10; i++)
            {
                if(!Char.IsDigit(idcat[i]))
                {
                    throw new ArgumentException("invalid Id");
                }
            }
            for(int i = 10;  i < 13; i++)
            {

            }
        }
    }
}
