using Moq;
using OnlineRetailShopping.Models.ViewModel;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrder(OrderViewModel entity)
        {
          
            var result = await _orderRepository.create(entity);
            return result;
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var result = await _orderRepository.delete(id);
            if (!result)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var result = await _orderRepository.GetAll();
            return result;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var result = await _orderRepository.GetById(id);
            return result;
        }

        public async Task<bool> UpdateOrder(Guid id, int quantity)
        {
            var result = await _orderRepository.update(id, quantity);
            if (!result)
            {
                return false;
            }
            return true;

        }
    }
}
