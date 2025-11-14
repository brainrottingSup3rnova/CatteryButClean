using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public record AdopterPersistenceDto(
        string Name,
        string Surname,
        string Email,
        string PhoneNumber,
        string street,
        string civicNumber,
        string city,
        string postalCode,
        string TIN
        );
}
