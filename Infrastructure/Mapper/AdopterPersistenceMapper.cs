using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Mapper
{
    public static class AdopterPersistenceMapper
    {
        public static AdopterPersistenceDto ToAdopterPersistenceDto(this Adopter adopter)
        {
            return new AdopterPersistenceDto(
                adopter.Name,
                adopter.Surname,
                adopter.Email,
                adopter.PhoneNumber,
                adopter.Address,
                adopter.TIN
            );
        }

        public static Adopter ToAdopterPersistence(this AdopterPersistenceDto adopterPersistenceDto)
        {
            if (adopterPersistenceDto == null)
            {
                throw new ArgumentNullException("AdopterPersistenceDto cannot be null.");
            }
            else return new Adopter(
                adopterPersistenceDto.Name,
                adopterPersistenceDto.Surname,
                adopterPersistenceDto.Email,
                adopterPersistenceDto.PhoneNumber,
                adopterPersistenceDto.Address,
                adopterPersistenceDto.TIN
            );
        }
    }
}
