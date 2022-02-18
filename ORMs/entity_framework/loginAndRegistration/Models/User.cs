using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginAndRegistration.Models
{
    public class User
    {
        //Basic things a model needs when going into MySQL
        // It needs a key
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        //It also needs a createdAt and updatedAt
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // NotMapped means it will NOT go into our database
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPass {get;set;}

    }
}