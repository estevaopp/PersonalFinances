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

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailValid { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}