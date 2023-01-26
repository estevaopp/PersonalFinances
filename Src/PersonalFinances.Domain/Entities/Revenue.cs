using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Domain.Entities
{
    public class Revenue : EntityBase
    {
        public string Name { get; private set; }
        
        public DateTime Date { get; private set; }

        public decimal Value { get; private set; }

        public string Description { get; private set; }

        public int UserId { get; private set; }

        public User User { get; private set; }

        public int RevenueCategoryId { get; private set; }

        public virtual RevenueCategory RevenueCategory { get; private set; }


        protected Revenue() { }

        public Revenue(string name, int revenueCategoryId, DateTime? date, decimal value, string description, int userId) 
        {
            ValidationName(name);
            ValidationValue(value);
            ValidationDescription(description);
            Name = name;
            RevenueCategoryId = revenueCategoryId;
            Date = date ?? DateTime.Now.Date;
            Value = value;
            Description = description;
            UserId = userId;
        }


        public void Update(string name, int revenueCategoryId, DateTime date, decimal value, string description) 
        {
            ValidationName(name);
            ValidationValue(value);
            ValidationDescription(description);
            Name = name;
            RevenueCategoryId = revenueCategoryId;
            Date = date.Date;
            Value = value;
            Description = description;
        }


        private void ValidationName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Este campo é obrigatório", nameof(Name), ErroEnum.ResourceInvalidField);

            if (name.Length < 3 || name.Length > 30)
                throw new BusinessException("O nome deve ter entre 3 e 30 caracteres", nameof(Name), ErroEnum.ResourceInvalidField);
        }

        private void ValidationDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
                throw new BusinessException("Este campo é obrigatório", nameof(Description), ErroEnum.ResourceInvalidField);

            if (description.Length < 5 || description.Length > 100)
                throw new BusinessException("A descrição deve ter entre 5 e 100 caracteres", nameof(Description), ErroEnum.ResourceInvalidField);
        }

        private void ValidationValue(decimal value)
        {
            if(value <= 0)
                throw new BusinessException("Valor tem que ser maior que 0", nameof(Value), ErroEnum.ResourceInvalidField);
        }
    }
}