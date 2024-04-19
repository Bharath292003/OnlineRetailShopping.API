using Microsoft.EntityFrameworkCore;
using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository
{
    public class CombineContext : DbContext

    {
        public CombineContext(DbContextOptions<CombineContext> options) : base(options)
        {


        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> product { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
