using ArtTableWeb.Application.Exceptions;
using ArtTableWeb.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Rules.Product
{
    public class ProductBusinessRules
    {
        private readonly IProductReadRepository _productReadRepository;

        public ProductBusinessRules(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task ProductNameCanNotBeDuplicatedWhenInserted(string name)
        {
            Domain.Entities.Product? result = _productReadRepository.Table.FirstOrDefault(c => c.Name == name);
            if (result != null) throw new BusinessException("Ürün Adı mevcut!");
        }
        public async Task ProductShouldExistWhenRequested(Domain.Entities.Product product)
        {
            if (product == null) throw new BusinessException("Ürün Mevcut değil.");
        }
        public async Task ProductNameMustBeExistedWhenDeleted(string id)
        {
            Domain.Entities.Product? result = _productReadRepository.Table.FirstOrDefault(c => c.Id.ToString() == id);
            if (result != null) throw new BusinessException("Ürün mevcut olmadığı için silinemedi.");
        }
    }
}
