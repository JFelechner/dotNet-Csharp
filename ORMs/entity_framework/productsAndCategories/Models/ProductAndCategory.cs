using System;
using System.ComponentModel.DataAnnotations;

namespace productsAndCategories.Models
{
    public class ProductAndCategory
    {
        [Key]
        public int ProductsAndCategoriesId {get;set;}
        public int ProductId {get;set;}
        public int CategoryId {get;set;}
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}