using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandValidator:AbstractValidator<CreateAboutCommandRequest>
    {
        public CreateAboutCommandValidator()
        {
            RuleFor(a=>a.Details)
                .NotEmpty()
                .NotNull()
                .WithMessage("Detay Boş geçilemez!")
                .MinimumLength(10)
                .MaximumLength(500)
                .WithMessage("Lütfen en az 10 en fazla 500 karakter olacak şekilde giriniz.");
        }
    }
}
