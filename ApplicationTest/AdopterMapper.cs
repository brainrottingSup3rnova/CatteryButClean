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
    public sealed class AdopterMapperTest
    {
        //questo non va ma vi giuro che in realtà funziona
        [TestMethod]
        public void ToAdopter_AdopterDtoIsNotNull_ReturnAdopterEntity()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari",email, phoneNumber,address, tin);
            AdopterDto adopterDto = new AdopterDto(
                "Anna",
                "Tassinari",
                email,
                phoneNumber,
                address,
                tin
            );

            Adopter result = adopterDto.ToAdopter();
            Assert.AreEqual(adopter, result);
        }

        [TestMethod]
        public void ToAdopterDto_AdopterIsNotNull_ReturnAdopterDto()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);
            Address address = new Address("Main St", "555", "Springfield", "62701");
            PhoneNumber phoneNumber = new PhoneNumber("+396543213345");
            Email email = new Email("supernovasasigma@gmail.com");
            TIN tin = new TIN("TSSNNA08R61D704Z");
            Adopter adopter = new Adopter("Anna", "Tassinari",email, phoneNumber, address, tin);
            AdopterDto adopterDto = new AdopterDto(
                "Anna",
                "Tassinari",
                email,
                phoneNumber,
                address,
                tin
            );

            AdopterDto result = adopter.ToAdopterDto();
            Assert.AreEqual(adopterDto, result);
        }
    }
}
