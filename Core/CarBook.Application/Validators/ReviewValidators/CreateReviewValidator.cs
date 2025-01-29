using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyin");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter girişi yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen Puan Değerini Boş Geçmeyin");
            RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakter girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen En Az 20 Karakter girişi yapınız");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen Müşteri göreselini Boş Geçmeyin").MinimumLength(10).WithMessage("Lütfen En Az 10 Karater Girişi Yapınız")
               .MaximumLength(200).WithMessage("Lütfen En Fazla 200 Karater Girişi Yapınız");
        }
    }
}
