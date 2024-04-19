using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Entities
{
    public class Order
    {
        [Key]
        public Guid orderId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid customerId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Boolean IsCancel { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
