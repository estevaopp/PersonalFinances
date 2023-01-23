using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.ViewModel.Response
{
    public class UserResponse
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Username is Required")]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage ="The Email is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsEmailValid { get; set; }

        public DateTime CreationDate { get; }

        [Required(ErrorMessage ="The User's Role is Required")]
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}