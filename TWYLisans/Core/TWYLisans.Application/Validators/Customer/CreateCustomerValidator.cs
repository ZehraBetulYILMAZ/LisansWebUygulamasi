using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Customer;
using TWYLisans.Application.ViewModels.Products;

namespace TWYLisans.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<VM_Create_Customer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.firstName)
                .NotEmpty().WithMessage("İsim Alanı boş Geçilemez")
                .NotNull().WithMessage("Lütfen isim alanına bir değer giriniz");
            RuleFor(c => c.lastName)
                .NotEmpty().WithMessage("Soyisim Alanı boş Geçilemez")
                .NotNull().WithMessage("Lütfen soyisim alanına bir değer giriniz");
            RuleFor(c => c.ePosta)
                .NotEmpty().WithMessage("Eposta Alanı boş Geçilemez")
                .NotNull().WithMessage("Lütfen ePosta alanına bir değer giriniz")
                .EmailAddress()
                .WithMessage("lütfen değeri mail formatında giriniz");
            RuleFor(c => c.phoneNumber)
                .NotEmpty().WithMessage("Telefon No Alanı boş Geçilemez")
                .NotNull().WithMessage("Lütfen telefon no alanına bir değer giriniz")
                .Length(12).WithMessage("Telefon Numarası 12 karakter olmalıdır");

        }
    }
}
