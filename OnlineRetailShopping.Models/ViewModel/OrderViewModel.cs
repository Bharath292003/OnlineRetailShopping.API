using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Models.ViewModel
{
    public class OrderViewModel
    {

        public Guid customerId { get; set; }

        public Guid productId { get; set; }
        public int quantity { get; set; }

    }
}
