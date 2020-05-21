using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("cartdetails")]
    public class CartDetail
    {
        public int? ProductId { get; set; }
        public Product product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal SubTotal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }

        [StringLength(5)]
        public string PostalCode { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
    }
}