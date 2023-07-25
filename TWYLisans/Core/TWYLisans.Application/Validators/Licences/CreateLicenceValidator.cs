using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWYLisans.Application.ViewModels.Licences;

namespace TWYLisans.Application.Validators.Licences
{
    public class CreateLicenceValidator : AbstractValidator<VM_Create_Licence>
    {
        public CreateLicenceValidator()
        {
            RuleFor(p => p.licencekey)
             .NotEmpty()
             .NotNull()
            .WithMessage("Lütfen ürün adını boş geçemyiniz");
            RuleFor(p => p.endingDate)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen lisans kullanım dolum zamaını giriniz");
            RuleFor(p => p.productId)
              .NotEmpty()
              .NotNull()
              .WithMessage("Lütfen bir ürün seçiniz");
        }
    }
}
