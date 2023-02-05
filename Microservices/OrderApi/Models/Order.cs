using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public int Order_Id { get; set; }

        public string Name { get; set; }

        [Column("customer_id")]
        public string Customer_Id { get; set; }
    }
}

