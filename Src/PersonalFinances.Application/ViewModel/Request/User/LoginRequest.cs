using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Application.ViewModel.Request.User
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="The Email is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage ="The Password is Required")]
        public string Password { get; set; }
    }
}