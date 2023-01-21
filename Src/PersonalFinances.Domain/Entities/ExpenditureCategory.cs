using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Domain.Entities
{
    public class ExpenditureCategory : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Expenditure> Expenditures { get; private set; }


        protected ExpenditureCategory() { }

        public ExpenditureCategory(string name, string description)
        {
            ValidationName(name);
            ValidationDescription(description);
            Name = name;
            Description = description;
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

            if (description.Length < 5 || description.Length > 60)
                throw new BusinessException("O descrição deve ter entre 5 e 60 caracteres", nameof(Description), ErroEnum.ResourceInvalidField);
        }
    }
}