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

        public void AddCat(CatDto cat)
        {
            if(string.IsNullOrWhiteSpace(cat.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            _catteryRepository.AddCat(cat.ToCat());
        }

        public void RegisterAdoption(AdoptionDto adoption)
        {
            if(adoption == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }
            _catteryRepository.RegisterAdoption(adoption.ToAdoption());
        }

        public void CancelAdoption(AdoptionDto adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }
            _catteryRepository.CancelAdoption(adoption.ToAdoption());
        }

        public void RegisterAdopter(AdopterDto adopter)
        {
            if(adopter == null)
            {
                throw new ArgumentNullException("The adopter can't be null");
            }
            _catteryRepository.RegisterAdopter(adopter.ToAdopter());
        }

        public CatDto GetCatByName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            CatDto? cat = _catteryRepository.GetCatByName(name).ToCatDto();
            if(cat == null)
            {
                throw new KeyNotFoundException($"Cat with name '{name}' not found.");
            }
            else return cat;
        }

        public AdopterDto GetAdopterByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Adopter name cannot be null or empty.");
            }
            AdopterDto? adopter = _catteryRepository.GetAdopterByName(name).ToAdopterDto();
            if (adopter == null)
            {
                throw new KeyNotFoundException($"Adopter with name '{name}' not found.");
            }
            else return adopter;
        }

        public AdoptionDto GetAdoption(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            AdoptionDto? adoption = _catteryRepository.GetAdoption(name).ToAdoptionDto();
            if (adoption == null)
            {
                throw new KeyNotFoundException($"Adoption for cat with name '{name}' not found.");
            }
            else return adoption;
        }

        public CatDto[]? GetAllCats()
        {
            Cat[] cats = _catteryRepository.GetAllCats();
            return cats.Select(c => c.ToCatDto()).ToArray();
        }

        public AdoptionDto[]? GetAllAdoptions()
        {
            Adoption[] adoptions = _catteryRepository.GetAllAdoptions();
            return adoptions.Select(c => c.ToAdoptionDto()).ToArray();
        }

        public AdopterDto[]? GetAllAdopters()
        {
            Adopter[] adopters = _catteryRepository.GetAllAdopters();
            return adopters.Select(c => c.ToAdopterDto()).ToArray();
        } 
    }
}
