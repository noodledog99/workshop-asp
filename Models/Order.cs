using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace workshop_asp.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }
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
        public decimal Total { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}