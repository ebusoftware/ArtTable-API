using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProductCount = _productReadRepository.GetAll().Count();

            var products = _productReadRepository.GetAll().Skip(request.Page * request.Size).Take(request.Size)

                .Include(p => p.ProductImageFiles)
                .Include(c =>c.Category)
                .Select(p => new 
                {
                    p.Id,
                    p.Name,
                    p.Content,
                    p.Title,
                    p.Price,
                    p.Stock,
                    p.Status,
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.Category.CategoryName,
                    p.ProductImageFiles
                }).ToList();

           



            return new()
            {
                Products= products,
                TotalProductCount= totalProductCount
            };
        }
    }
}
