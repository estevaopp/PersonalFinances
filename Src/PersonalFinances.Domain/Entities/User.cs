using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool IsEmailValid { get; private set; }

        public int UserRoleId { get; private set; }

        public virtual UserRole UserRole { get; private set; }


        protected User() { }

        public User(string username, string email, string password, int userRoleId)
        {
            Username = username;
            Email = email;
            Password = password;
            IsEmailValid = false;
            UserRoleId = userRoleId;
        }


        public void Update(string username, string email, string password, int userRoleId)
        {
            Username = username;
            Email = email;
            Password = password;
            UserRoleId = userRoleId;
        }

        public void ValidationEmail()
        {
            IsEmailValid = true;
        }

        
        private void ValidationPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new Exception();
            
        } 
    }
}