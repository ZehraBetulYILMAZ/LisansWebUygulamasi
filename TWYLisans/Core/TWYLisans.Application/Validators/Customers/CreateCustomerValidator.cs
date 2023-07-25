using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customers;

namespace TWYLisans.Application.Validators.Customers
{
    public class CreateCustomerValidator : AbstractValidator<VM_Create_Customer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.companyName)
               .NotEmpty().NotNull().WithMessage("İsim alanı boş geçilemez");
            RuleFor(c => c.townname)
               .NotEmpty().NotNull().WithMessage("İlçe alanı boş geçilemez");
            RuleFor(c => c.cityname)
                .NotEmpty().NotNull().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(c => c.phoneNumber)
                .MaximumLength(20).WithMessage("Telefon No 20 karakteri geçemez");
               
        } 
    }
}
