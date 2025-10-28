using Infrastructure.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public static class AdoptionPersistenceMapper
    {
        public static AdoptionPersistenceDto ToAdoptionPersistenceDto(this Adoption adoption)
        {
            if(adoption == null)
            {
                throw new ArgumentNullException("Adoption cannot be null.");
            }
            else return new AdoptionPersistenceDto(
                adoption.Cat.ToCatPersistenceDto(),
                adoption.Adopter.ToAdopterPersistenceDto(),
                adoption.AdoptionDate
            );
        }

        public static Adoption ToAdoptionPersistence(this AdoptionPersistenceDto adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException("Adoption can't be null");
            }
            else return new Adoption(
                adoption.Adopter.ToAdopterPersistence(),
                adoption.Cat.ToCatPersistence(),
                adoption.AdoptionDate
            );
        }
    }
}
