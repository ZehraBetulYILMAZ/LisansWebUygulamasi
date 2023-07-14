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
            RuleFor(c => c.firstName)
                .NotEmpty().NotNull().WithMessage("İsim alanı boş geçilemez");
            RuleFor(c => c.lastName)
                .NotEmpty().NotNull().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(c => c.ePosta)
                .NotEmpty().NotNull().WithMessage("EPosta alanı boş geçilemez")
                .EmailAddress();
            RuleFor(c => c.phoneNumber)
                .NotEmpty().NotNull().WithMessage("Telefon No alanı boş geçilemez")
                .Length(12);
        } 
    }
}
