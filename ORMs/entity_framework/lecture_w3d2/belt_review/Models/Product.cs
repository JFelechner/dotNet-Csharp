using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace belt_review.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}

        [Required]
        public string ProductName {get;set;}

        [Required]
        public string Picture {get;set;}

        [Required]
        [Range(0.01, 900000000.00)]
        public double Price {get;set;}

        [Required]
        public int Quantity {get;set;}

        // We need to know who posted the product
        // It is one person so it's one to many
        public int UserId {get;set;}
        // Need our one to many navigation property

        public User Seller {get;set;}
        // Need to set up our many to many
        public List<Order> OrderedBy {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateddAt {get;set;} = DateTime.Now;
    }
}