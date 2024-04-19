using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using OnlineRetailShopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            
        }
        public async Task<Customer> CreateCustomer(Customer entity)
        {
            var result = await _customerRepository.Create(entity);
            return result;
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task<List<Customer>> GetCustomerAll()
        {
            var result = await _customerRepository.GetAll();
            return result;
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var result = await _customerRepository.GetById(id);
            return result;
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            var result = await _customerRepository.GetByName(name);
            return result;
        }

        public async Task UpdateCustomer(Customer entity)
        {
             await _customerRepository.Update(entity);
           
        }
    }
}
