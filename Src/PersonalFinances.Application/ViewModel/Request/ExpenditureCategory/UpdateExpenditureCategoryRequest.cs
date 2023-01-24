using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Application.ViewModel.Request.ExpenditureCategory
{
    public class UpdateExpenditureCategoryRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name is Required")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage ="The Description is Required")]
        [MinLength(3)]
        [MaxLength(60)]
        public string Description { get; set; }
    }
}