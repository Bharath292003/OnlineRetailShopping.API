using Microsoft.EntityFrameworkCore;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly CombineContext _dbcontext;
        public ProductRepository(CombineContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Product> Create(Product entity)
        {
            entity.productId = Guid.NewGuid();
            _dbcontext.product.Add(entity);
            await save();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var prodel = await _dbcontext.product.FindAsync(id);
            if (prodel == null)
            {
                return false;
            }
            _dbcontext.product.Remove(prodel);
            await save();
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> pro = await _dbcontext.product.ToListAsync();
            return pro;
        }

        public async Task<Product> GetById(Guid id)
        {
            Product pro = await _dbcontext.product.FindAsync(id);
            return pro;
        }

        public async Task<Product> GetByName(string Name)
        {
            Product pro = await _dbcontext.product.FirstOrDefaultAsync(Off => Off.ProductName == Name);
            return pro;
        }

        public async Task save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> Update(Guid id, Product entity)
        {
            if (id != entity.productId)
            {
                return false;
            }
            _dbcontext.Entry(entity).State = EntityState.Modified;

            await _dbcontext.SaveChangesAsync();

            return true;
        }


    }
}
