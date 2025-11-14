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
                adopter.Email.Value,
                adopter.PhoneNumber.Value,
                adopter.Address.Street,
                adopter.Address.CivicNumber,
                adopter.Address.City,
                adopter.Address.PostalCode,
                adopter.TIN.Value
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
                new Email(adopterPersistenceDto.Email),
                new PhoneNumber(adopterPersistenceDto.PhoneNumber),
                new Address(adopterPersistenceDto.street,adopterPersistenceDto.civicNumber,adopterPersistenceDto.city,adopterPersistenceDto.postalCode),
                new TIN(adopterPersistenceDto.TIN)
            );
        }
    }
}
