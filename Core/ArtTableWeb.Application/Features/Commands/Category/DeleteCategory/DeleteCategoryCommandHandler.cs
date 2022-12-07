
using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Application.Rules.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameMustBeExistedWhenDeleted(request.Id);
            await _categoryWriteRepository.RemoveAsync(request.Id);
            await _categoryWriteRepository.SaveAsync(); 
            return new();
        }
    }
}
