using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic;

namespace felechnerCSharpExam.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2)]
        public string Name {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // many to many
        public List<RSVP> RSVPs {get;set;}
        public List<ShinDig> ShinDigs {get;set;}

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PassConfirm {get;set;}
    }
}