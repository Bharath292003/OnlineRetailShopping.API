using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAll();
        Task<Product> GetProductById(Guid id);
        Task<Product> GetProductByName(string name);
        Task<Product> CreateProduct(Product entity);
        Task<bool> UpdateProduct(Guid id, Product entity);
        Task<bool> DeleteProduct(Guid id);

    }
}
