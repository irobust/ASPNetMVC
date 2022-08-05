using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "You must enter product name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType("nvarchar(255)")]
        public string Description { get; set; }

        [Required]
        [DataType("decimal(19,4)")]
        [Range(0.00, double.MaxValue)]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
