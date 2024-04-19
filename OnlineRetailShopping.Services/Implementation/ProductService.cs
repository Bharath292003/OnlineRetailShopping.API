using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Implementations;
using OnlineRetailShopping.Repository.Interface;
using OnlineRetailShopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<Product> CreateProduct(Product entity)
        {
            return await _productRepository.Create(entity);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var result =  await _productRepository.Delete(id);
            if (!result)
            {
                return false;
            }
            return true;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<List<Product>> GetProductsAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<bool> UpdateProduct(Guid id, Product entity)
        {
            var result = await _productRepository.Update(id, entity);
            if (!result)
            {
                return false;
            }
            return true;

        }

        public async Task<Product> GetProductByName(string name)
        {
            var result = await _productRepository.GetByName(name);
            return result;

        }
    }
}
