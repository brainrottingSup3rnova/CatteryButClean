﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdoptionDto(
        AdopterDto Adopter,
        CatDto Cat,
        DateTime AdoptionDate
        );
}
