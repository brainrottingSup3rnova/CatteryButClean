using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDto(
        string Name,
        string Surname,
        Email Email,
        PhoneNumber PhoneNumber,
        Address Address,
        TIN TIN
        );
}
