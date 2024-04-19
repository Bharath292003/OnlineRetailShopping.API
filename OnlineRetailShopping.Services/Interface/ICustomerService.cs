using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAll();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByName(string name);
        Task<Customer> CreateCustomer(Customer entity);
        Task UpdateCustomer(Customer entity);
        Task DeleteCustomer(Guid id);

    }
}
