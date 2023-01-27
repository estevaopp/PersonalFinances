using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Domain.Entities
{
    public class ExpenditureCategory : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int UserId { get; private set;}

        [JsonIgnore]
        public virtual User User { get; private set; }

        [JsonIgnore]
        public virtual List<Expenditure> Expenditures { get; private set; }


        protected ExpenditureCategory() { }

        public ExpenditureCategory(string name, string description, int userId)
        {
            ValidationName(name);
            ValidationDescription(description);
            Name = name;
            Description = description;
            UserId = userId;
        }


        public void Update(string name, string description)
        {
            ValidationName(name);
            ValidationDescription(description);
            Name = name;
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
                throw new BusinessException("O descrição deve ter entre 5 e 100 caracteres", nameof(Description), ErroEnum.ResourceInvalidField);
        }
    }
}