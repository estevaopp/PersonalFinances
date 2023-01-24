using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Application.ViewModel.Response
{
    public class RevenueCategoryResponse
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}