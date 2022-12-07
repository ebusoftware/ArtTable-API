using ArtTableWeb.Application.Features.Commands.Category.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {

        public UpdateCategoryCommandValidator()
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Kategori Boş geçilemez!")
               .MinimumLength(2)
               .MaximumLength(150)
               .WithMessage("Lütfen en az 2 en fazla 150 karakter olacak şekilde giriniz.");
        }

    }
}
