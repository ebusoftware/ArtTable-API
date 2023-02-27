using ArtTableWeb.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product products = await _productReadRepository.GetByIdAsync(request.Id);
            return new() 
            {
                Name=products.Name,
                Price=products.Price,
                Stock=products.Stock,
                Status=products.Status,
                CategoryId=products.Category.CategoryName,
                Content=products.Content,
                Title=products.Title,

                
            };
        }
    }
}
