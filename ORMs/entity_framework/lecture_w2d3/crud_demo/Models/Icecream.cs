using System;
using System.ComponentModel.DataAnnotations;

namespace crud_demo.Models
{
    public class Icecream
    {
        [Key]
        public int IcecreamId {get;set;}

        //Here are our attributes
        [Required]
        public string Flavor {get;set;}
        [Required]
        public string Topping {get;set;}
        [Required]
        public bool hasCherry {get;set;}
        [Required]
        public string Container {get;set;}


        //Dont forget your createdAt and updatedAt
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}