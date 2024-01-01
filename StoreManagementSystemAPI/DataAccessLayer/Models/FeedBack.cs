using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(150)]
        public string ReviewFeedBack { get; set; }
        [ForeignKey("Review")]
        public int rid { get; set; }
        public virtual Review Review { get; set; }

    }
}
