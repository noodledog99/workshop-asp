using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(65, ErrorMessage = "product name at least 3 charactor", MinimumLength = 3)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [StringLength(300, ErrorMessage = "product name at least 3 charactor", MinimumLength = 3)]
        [Display(Name = "Product Detail")]
        public string ProductDetail { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Category Id")]
        public int? CategoryId { get; set; }
        public Category category { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [Display(Name = "Units On Order")]
        public int UnitsOnOrder { get; set; }

        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}