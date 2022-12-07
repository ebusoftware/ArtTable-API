using ArtTableWeb.Application.Features.Commands.About.CreateAbout;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandValidator: AbstractValidator<UpdateAboutCommandRequest>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(a => a.Details)
                .NotEmpty()
                .NotNull()
                .WithMessage("Detayı Giriniz.");
        }
    }
}
