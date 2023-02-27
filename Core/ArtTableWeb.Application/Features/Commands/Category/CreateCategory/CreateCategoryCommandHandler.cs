using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Rules.Category;
using ArtTableWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

           await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

            await _categoryWriteRepository.AddAsync(new()
            {
                Description= request.Description,
                CategoryName = request.Name
            });
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
