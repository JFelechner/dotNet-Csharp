using System;
using System.ComponentModel.DataAnnotations;

namespace belt_review.Models
{
    public class Order
    {
        [Key]
        public int OrderId {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public int ProductId {get;set;}
        public Product Product {get;set;}

        // We need to know how much they ordered
        [Range(1, 1000000000000000)]
        public int Quantity {get;set;}
    }
}