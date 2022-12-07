using ArtTableWeb.Application.Exceptions;
using ArtTableWeb.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Rules.Category
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CategoryBusinessRules(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            Domain.Entities.Category? result =  _categoryReadRepository.Table.FirstOrDefault(c=>c.Name==name);
            if (result != null) throw new BusinessException("Kategori Zaten mevcut!");
        }

        public async Task CategoryShouldExistWhenRequested(Domain.Entities.Category category)
        {
            if (category == null) throw new BusinessException("Kategori Mevcut değil.");
        }
        public async Task CategoryNameMustBeExistedWhenDeleted(string id)
        {
            Domain.Entities.Category? result = _categoryReadRepository.Table.FirstOrDefault(c => c.Id.ToString() == id);
            if (result != null) throw new BusinessException("Kategori mevcut olmadığı için silinemedi.");
        }
        public async Task CategoryRequestsMustBeDifferent(string description,string name)
        {
            Domain.Entities.Category? result = _categoryReadRepository.Table.FirstOrDefault(c => c.Name == name && c.Description == description);
            if (result != null) throw new BusinessException("Girmiş olduğunuz değerler aynı.");
        }

    }
}
