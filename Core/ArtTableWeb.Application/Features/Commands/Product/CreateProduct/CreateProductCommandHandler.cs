using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
         readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {


             await _productWriteRepository.AddAsync(new() 
            {
                Stock=request.Stock,
                Content=request.Content,
                Name=request.Name,
                Price= request.Price,
                Title = request.Title,
                CategoryId = Guid.Parse(request.CategoryId)
                
            });
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
