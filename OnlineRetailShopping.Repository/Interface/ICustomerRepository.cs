using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByName(string Name);
        Task<Customer> Create(Customer entity);
        Task Update(Customer entity);
        Task Delete(Guid id);
        Task save();
    }
}
