using OnlineRetailShopping.Models.ViewModel;
using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> create(OrderViewModel entity);
        Task<bool> update(Guid orderId, int entity);
        Task<bool> delete(Guid orderID);
        Task save();
    }
}
