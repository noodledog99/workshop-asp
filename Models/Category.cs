using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "category name at least 2 charactor", MinimumLength = 2)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        [StringLength(250, ErrorMessage = "description at least 2 charactor", MinimumLength = 2)]
        public string Description { get; set; }
    }
}