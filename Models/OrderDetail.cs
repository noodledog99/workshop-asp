using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        public string OrderId { get; set; }

        [Key, Column(Order = 1)]
        public int? ProductId { get; set; }
        public Product product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal SubTotal { get; set; }

    }
}