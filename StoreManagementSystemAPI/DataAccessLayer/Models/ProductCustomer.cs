using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ProductCustomer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int productID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public int Quantity { get; set; }
        public decimal Granttotal { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
