using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Application.ViewModel.Request.Revenue
{
    public class CreateRevenueRequest
    {
        [Required(ErrorMessage ="The Name is Required")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="The Date is Required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="The Value is Required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage ="The Description is Required")]
        [MinLength(3)]
        [MaxLength(60)]
        public string Description { get; set; }

        [Required(ErrorMessage ="The Revenue's Category is Required")]
        public int RevenueCategoryId { get; set; }
    }
}