using AutoMapper;
using OnlineRetailShopping.Models.ViewModel;
using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // source,destination
            CreateMap<OrderViewModel, Order>().ReverseMap();
        }
    }
}
