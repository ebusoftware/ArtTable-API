using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Rules.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Category.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest,List<GetCategoryQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }


        public async Task<List<GetCategoryQueryResponse>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            
            var categories = _categoryReadRepository.GetAll();

           return categories.Select(c => new GetCategoryQueryResponse
            {
                CategoryId = c.Id.ToString(),
                CategoryName = c.CategoryName,
                CategoryStatus = c.CategoryStatus,
                Description = c.Description,
            }).ToList();
            
        }
    }
}
