using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cattery
    {
        private List<Cat> _catsInTheCattery;

        public Cattery(List<Cat>? listOfCats)
        {
            if(listOfCats == null)
            {
                _catsInTheCattery = new List<Cat>();
            }
            else
            {
                _catsInTheCattery = listOfCats;
            }
        }
    }
}
