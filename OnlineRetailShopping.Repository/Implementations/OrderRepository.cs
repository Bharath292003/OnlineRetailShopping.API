using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineRetailShopping.Models.ViewModel;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CombineContext _dbcontext;
        private readonly IMapper _mapper;
        public OrderRepository(CombineContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<Order> create(OrderViewModel entity)
        {
            var order = _mapper.Map<Order>(entity);
            _dbcontext.Order.Add(order);
            var gotorder = await _dbcontext.product.FindAsync(entity.productId);
            gotorder.quantity -= entity.quantity;
            await save();
            return order;
        }

        public async Task<bool> delete(Guid orderID)
        {
            var orderdel = await _dbcontext.Order.FindAsync(orderID);
            if (orderdel == null)
            {
                return false;
            }
            _dbcontext.Order.Remove(orderdel);
            await save();
            return true;
        }

        public async Task<List<Order>> GetAll()
        {

            List<Order> Orders = await _dbcontext.Order.ToListAsync();
            return Orders;
        }

        public async Task<Order> GetById(Guid id)
        {
            Order Orders = await _dbcontext.Order.FindAsync(id);
            return Orders;
        }

        public async Task save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> update(Guid orderId, int quantity)
        {
            //if (orderId != entity.orderId)
            //{
            //    return false;
            //}
            var order = await _dbcontext.Order.FindAsync(orderId);
            order.quantity = quantity;
            //_dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }



    }
}
