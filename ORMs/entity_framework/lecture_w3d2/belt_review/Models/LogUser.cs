using System;
using System.ComponentModel.DataAnnotations;

namespace belt_review.Models
{
    public class LogUser
    {

        [Required]
        [EmailAddress]
        public string LogEmail {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}

    }
}