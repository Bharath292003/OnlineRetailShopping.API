using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Interface
{
    public interface IAuthorizationRepository
    {
        Task<User> Role(int userId);
    }
}
