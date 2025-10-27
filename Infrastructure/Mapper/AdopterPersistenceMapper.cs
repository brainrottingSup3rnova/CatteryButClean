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
    }
}
