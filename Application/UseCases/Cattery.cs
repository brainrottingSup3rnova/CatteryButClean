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

        public void AddCat(CatDto catDto)
        {
            if(string.IsNullOrWhiteSpace(catDto.Name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }

            Cat cat = catDto.ToCat();
            _catteryRepository.AddCat(cat);
        }

        public void RegisterAdoption(AdoptionDto adoptionDto)
        {
            if(adoptionDto == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }

            Adoption adoption = adoptionDto.ToAdoption();
            _catteryRepository.RegisterAdoption(adoption);
        }

        public void CancelAdoption(AdoptionDto adoptionDto)
        {
            if (adoptionDto == null)
            {
                throw new ArgumentNullException("The adoption can't be null");
            }
            Adoption adoption = adoptionDto.ToAdoption();
            _catteryRepository.CancelAdoption(adoption);
        }

        public void RegisterAdopter(AdopterDto adopterDto)
        {
            if(adopterDto == null)
            {
                throw new ArgumentNullException("The adopter can't be null");
            }
            Adopter adopter = adopterDto.ToAdopter();
            _catteryRepository.RegisterAdopter(adopter);
        }

        public CatDto? GetCatByName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cat name cannot be null or empty.");
            }
            Cat? cat = _catteryRepository.GetByName(name);
            return cat?.ToCatDto();
        }
    }
}
