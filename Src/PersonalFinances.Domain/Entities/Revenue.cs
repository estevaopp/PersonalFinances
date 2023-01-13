using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Entities
{
    public class Revenue : EntityBase
    {
        public string Name { get; private set; }

        public DateTime Date { get; private set; }

        public decimal Value { get; private set; }

        public int RevenueTypeId { get; private set; }

        public virtual RevenueType RevenueType { get; private set; }


        protected Revenue() { }

        public Revenue(string name, int revenueTypeId, DateTime? date) 
        {
            Name = name;
            RevenueTypeId = revenueTypeId;
            Date = date ?? DateTime.Now;
        }


        public void Update(string name, int revenueTypeId, DateTime? date) 
        {
            Name = name;
            RevenueTypeId = revenueTypeId;
            Date = date ?? DateTime.Now;
        }
    }
}