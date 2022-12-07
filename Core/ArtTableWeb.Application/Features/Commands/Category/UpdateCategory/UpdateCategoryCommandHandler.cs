

using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Rules.Category;
using ArtTableWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly CategoryBusinessRules _categoryBusinessRules;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryRequestsMustBeDifferent(request.Description,request.Name);
            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(request.Id);

            category.Description = request.Description;
            category.Name = request.Name;
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
