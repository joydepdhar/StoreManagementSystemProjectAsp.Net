using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

    }
}
