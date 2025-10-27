﻿using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToAdoption(this AdoptionDto adoptionDto)
        {
            if (adoptionDto == null)
            {
                throw new ArgumentNullException("AdopterDto cannot be null.");
            }
            else return new Adoption(
                adoptionDto.Adopter.ToAdopter(),
                adoptionDto.Cat.ToCat(),
                adoptionDto.AdoptionDate
            );
        }

        public static AdoptionDto ToAdoptionDto(this Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException("Adoption cannot be null.");
            }
            else return new AdoptionDto(
                adoption.Adopter.ToAdopterDto(),
                adoption.Cat.ToCatDto(),
                adoption.AdoptionDate
            );
        }
    }
}
