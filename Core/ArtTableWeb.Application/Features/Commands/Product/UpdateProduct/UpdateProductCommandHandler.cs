using ArtTableWeb.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        IProductWriteRepository _productWriteRepository;
        IProductReadRepository _productReadRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Content = request.Content;
            product.Price = request.Price;
            product.CategoryId = Guid.Parse(request.CategoryId);
            product.Title = request.Title;
            product.Name = request.Name;
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
