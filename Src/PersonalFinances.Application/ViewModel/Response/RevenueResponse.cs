using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.ViewModel.Response
{
    public class RevenueResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string Description { get; set; }

        public int RevenueCategoryId { get; set; }

        public RevenueCategory RevenueCategory { get; set; }
    }
}