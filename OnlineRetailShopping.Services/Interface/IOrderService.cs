using OnlineRetailShopping.Models.ViewModel;
using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid id);
        Task<Order> CreateOrder(OrderViewModel entity);
        Task<bool> UpdateOrder(Guid id, int quantity);
        Task<bool> DeleteOrder(Guid id);
    }
}
