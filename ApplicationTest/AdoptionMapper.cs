using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest
{
    [TestClass]
    public sealed class AdoptionMapperTest
    {
        [TestMethod]
        public void ToAdoption_AdoptionDtoIsNotNull_ReturnAdoptionEntity()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);
            Adoption adoption = new Adoption(adopter, cat, new DateTime(2020, 05, 20));
            AdoptionDto adoptionDto = new AdoptionDto(
                adopter.ToAdopterDto(),
                cat.ToCatDto(),
                new DateTime(2020, 05, 20)
            );

            Adoption result = adoptionDto.ToAdoption();
            Assert.AreEqual(adoptionDto.AdoptionDate, result.AdoptionDate);
        }

        [TestMethod]
        public void ToAdoptionDto_AdoptionIsNotNull_ReturnAdoptionDto()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari", email, phoneNumber, address, tin);
            Adoption adoption = new Adoption(adopter, cat, new DateTime(2020, 05, 20));
            AdoptionDto adoptionDto = new AdoptionDto(
                adopter.ToAdopterDto(),
                cat.ToCatDto(),
                new DateTime(2020, 05, 20)
            );

            AdoptionDto result = adoption.ToAdoptionDto();
            Assert.AreEqual(adoption.AdoptionDate, result.AdoptionDate);
        }
    }
}
