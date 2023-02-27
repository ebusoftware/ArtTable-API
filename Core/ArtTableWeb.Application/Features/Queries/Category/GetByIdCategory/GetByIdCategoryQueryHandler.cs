using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Rules.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(request.Id);
            //Business Rule
            await _categoryBusinessRules.CategoryShouldExistWhenRequested(category);
            return new() 
            {
                CategoryId=category.Id.ToString(),
                Name= category.CategoryName,
                CategoryStatus=category.CategoryStatus,
                Description=category.Description
            };
        }
    }
}
