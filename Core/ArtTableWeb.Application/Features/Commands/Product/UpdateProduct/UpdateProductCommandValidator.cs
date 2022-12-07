using ArtTableWeb.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {

        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Ürün adı boş geçilemez!")
               .MinimumLength(2)
               .MaximumLength(150)
               .WithMessage("Lütfen en az 2 en fazla 150 karakter olacak şekilde giriniz.");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Kategori boş geçilemez.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stok boş geçilemez.")
                .Must(s => s >= 0)
                .WithMessage("Stok bilgisi negatif olamaz!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat bilgisi boş geçilemez.")
                .Must(a => a >= 0)
                .WithMessage("Fiyat bilgisi negatif olamaz!");

        }

    }
}
