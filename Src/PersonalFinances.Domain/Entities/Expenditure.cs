using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities.EntitiesBase;

namespace PersonalFinances.Domain.Entities
{
    public class Expenditure : EntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

    }
}