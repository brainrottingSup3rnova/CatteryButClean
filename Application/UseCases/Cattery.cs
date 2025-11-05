using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;

namespace Application.UseCases
{
    public class Cattery
    {
        private readonly ICatteryRepository _catteryRepository;
        public Cattery (ICatteryRepository catteryRepository)
        {
            _catteryRepository = catteryRepository;
        }

        public void AddCat(Cat cat)
        {
            if(string.IsNullOrWhiteSpace(cat.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            _catteryRepository.AddCat(cat);
        }

        public void RegisterAdoption(Adoption adoption)
        {
            if(adoption == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }
            _catteryRepository.RegisterAdoption(adoption);
        }

        public void CancelAdoption(Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }
            _catteryRepository.CancelAdoption(adoption);
        }

        public void RegisterAdopter(Adopter adopter)
        {
            if(adopter == null)
            {
                throw new ArgumentNullException("The adopter can't be null");
            }
            _catteryRepository.RegisterAdopter(adopter);
        }

        public Cat GetCatByName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            Cat? cat = _catteryRepository.GetByName(name);
            if(cat == null)
            {
                throw new KeyNotFoundException($"Cat with name '{name}' not found.");
            }
            else return cat;
        }

        public Cat[]? GetAllCats()
        {
            return _catteryRepository.GetAllCats();
        }
    }
}
