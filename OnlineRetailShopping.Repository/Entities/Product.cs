using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Entities
{
    public class Product
    {
        [Key]

        public Guid productId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int quantity { get; set; }
        public bool isActive { get; set; }
    }
}
