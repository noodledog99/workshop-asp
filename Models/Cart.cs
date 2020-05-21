using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("carts")]
    public class Cart
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [Column("UserId", Order = 1)]
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }

        public int PostalCode { get; set; }
        public int Phone { get; set; }

        //    SubTotal
        //        VatAmount
        //        NetTotal
    }
}