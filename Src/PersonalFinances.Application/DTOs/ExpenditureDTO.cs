using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.DTOs
{
    public class ExpenditureDTO
    {
        public int Id { get; set; }

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

        public int UserId { get; set; }

        public int ExpenditureCategoryId { get; private set; }

        public virtual ExpenditureCategory ExpenditureCategory { get; private set; }
    }
}