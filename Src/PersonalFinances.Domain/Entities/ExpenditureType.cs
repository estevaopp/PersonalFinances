using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Entities
{
    public class ExpenditureType : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }


        protected ExpenditureType() { }

        public ExpenditureType(string name, string description)
        {
            Name = name;
            Description = description;
        }


        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}