using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Interfaces
{
    public interface ICatteryRepository
    {
        void AddCat (Cat cat);
        void RegisterAdoption (Adoption adoption);
        void CancelAdoption (Adoption adoption);
        void RegisterAdopter (Adopter adopter);
        Cat? GetCatByName (string name);
        Cat[]? GetAllCats ();
        Adoption? GetAdoption(string name);
        Adoption[]? GetAllAdoptions ();
        Adopter[]? GetAllAdopters ();
        Adopter? GetAdopterByName (string name);
    }
}
