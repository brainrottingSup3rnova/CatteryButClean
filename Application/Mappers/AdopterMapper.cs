using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public static Adopter ToAdopter(this AdopterDto adopterDto)
        {
            if (adopterDto == null)
            {
                throw new ArgumentNullException(nameof(adopterDto), "AdopterDto cannot be null.");
            }
            else return new Adopter(
                adopterDto.Name,
                adopterDto.Surname,
                adopterDto.Email,
                adopterDto.PhoneNumber,
                adopterDto.Address,
                adopterDto.TIN
            );
        }
    }
}
