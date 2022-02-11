using System;
using System.ComponentModel.DataAnnotations;

namespace mvcDemo.Models

{
    public class Pet
    {
        [Required]
        public string petName {get;set;} //get/set allows communications with MySql
        
        [Required]
        [MinLength(2, ErrorMessage = "Pet type must be a minimum of 2 characters")]
        public string petType {get;set;}

        [Required]
        public int petAge {get;set;}

        [Required]
        public string petColor {get;set;}
    }
}