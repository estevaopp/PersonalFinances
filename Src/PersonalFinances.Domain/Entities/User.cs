using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool IsEmailValid { get; private set; }

        public DateTime CreationDate { get; }

        public int UserRoleId { get; private set; }

        public virtual UserRole UserRole { get; private set; }


        protected User() { }

        public User(string username, string email, string password, int userRoleId)
        {
            ValidationUsername(username);
            ValidationPassword(password);
            ValidationEmail(email);
            Username = username;
            Email = email;
            Password = password;
            IsEmailValid = false;
            UserRoleId = userRoleId;
            CreationDate = DateTime.Now;
        }

        public void UpdateIsEmailValid()
        {
            IsEmailValid = true;
        }

        public void UpdateUserRoleId(int userRoleId)
        {
            UserRoleId = userRoleId;
        }


        private void ValidationUsername(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
                throw new BusinessException("Este campo é obrigatório", nameof(Username), ErroEnum.ResourceInvalidField);

            if (username.Length < 3 || username.Length > 20)
                throw new BusinessException("O username deve ter entre 3 e 20 caracteres", nameof(Username), ErroEnum.ResourceInvalidField);
        }

        private void ValidationEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new BusinessException("Este campo é obrigatório", nameof(Email), ErroEnum.ResourceInvalidField);

            if (email.Length < 3 || email.Length > 100)
                throw new BusinessException("O Email deve ter entre 3 e 100 caracteres", nameof(Email), ErroEnum.ResourceInvalidField);
        }

        
        private void ValidationPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new BusinessException("Este campo é obrigatório", nameof(Password), ErroEnum.ResourceInvalidField);

            if (password.Length < 8 || password.Length > 100)
                throw new BusinessException("O Password deve ter entre 8 e 100 caracteres", nameof(Password), ErroEnum.ResourceInvalidField);
            
            if (!password.Any(char.IsNumber))
                throw new BusinessException("O Password deve ter no mínimo um Número", nameof(Password), ErroEnum.ResourceInvalidField);

            if (!password.Any(char.IsLetter))
                throw new BusinessException("O Password deve ter no mínimo uma letra", nameof(Password), ErroEnum.ResourceInvalidField);

            if(!password.Any(char.IsUpper))
                throw new BusinessException("O Password deve ter no mínimo uma letra maiúscula", nameof(Password), ErroEnum.ResourceInvalidField);

            if(!password.Any(char.IsLower))
                throw new BusinessException("O Password deve ter no mínimo uma letra minúscula", nameof(Password), ErroEnum.ResourceInvalidField);

            foreach (char c in password)
            {
                if (password.Where(x => x == c).Count() >= 3)
                    throw new BusinessException("Cada caracter do Password não pode ser repetido mais de 3 vezes", nameof(password), ErroEnum.ResourceInvalidField);
            }
        }
    }
}