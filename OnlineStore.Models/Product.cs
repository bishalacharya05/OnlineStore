using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OnlineStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl {  get; set; }
    }
}
