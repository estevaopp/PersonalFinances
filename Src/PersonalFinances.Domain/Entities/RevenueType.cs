using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Entities
{
    public class RevenueType : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        protected RevenueType() { }

        public RevenueType(string name, string description)
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