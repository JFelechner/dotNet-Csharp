


using System;
using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters long")]
        public string userFirstName {get;set;}
        
        [Required]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters long")]
        public string userLastName {get;set;}

        [Range(0, Int32.MaxValue, ErrorMessage="Age must be a positive number")]
        [Required]
        public int userAge {get;set;}

        [Required]
        [EmailAddress]
        public string userEmail{get;set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string userPassword {get;set;}
    }
}