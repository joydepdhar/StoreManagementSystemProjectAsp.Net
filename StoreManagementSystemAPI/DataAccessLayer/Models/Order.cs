using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderQuantity { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId {  get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
            Products = new List<Product>();
            OrderDetails = new List<OrderDetails>();
        }
    }

}
