using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShopping.Repository.Entities
{
    public class Customer
    {
        [Key]
        public Guid customerId { get; set; }
        [Required]
        public string? customerName { get; set; }
        public string? mobile { get; set; }
        public string? emailID { get; set; }
    }
}
