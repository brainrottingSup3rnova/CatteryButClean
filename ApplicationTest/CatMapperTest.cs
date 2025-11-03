using Application.Dto;
using Domain.Model.Entities;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest
{
    [TestClass]
    public sealed class CatMapperTest
    {
        [TestMethod]
        public void ToCat_CatDtoIsNotNull_ReturnCatEntity()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);

            CatDto catDto = new CatDto(
                "Kiwi",
                "Maine coon",
                true,
                new DateTime(2023, 1, 15),
                null,
                new DateTime(2022, 11, 20),
                "A friendly Siamese cat.",
                cat.Id
            );

            Cat result = catDto.ToCat();
            Assert.AreEqual(catDto.Name, result.Name);
        }

        [TestMethod]
        public void ToCatDto_CatIsNotNull_ReturnCatDto()
        {
            Cat cat = new Cat("Kiwi", "Maine coon", true, new DateTime(2009, 07, 13, 6, 8, 5), null, new DateTime(2009, 07, 13, 6, 8, 5), null);

            CatDto catDto = new CatDto(
                "Kiwi",
                "Maine coon",
                true,
                new DateTime(2023, 1, 15),
                null,
                new DateTime(2022, 11, 20),
                "A friendly Siamese cat.",
                cat.Id
            );

            CatDto result = cat.ToCatDto();
            Assert.AreEqual(cat.Name, result.Name);
        }
    }
}
