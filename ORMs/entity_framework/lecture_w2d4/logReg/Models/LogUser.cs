using System;
using System.ComponentModel.DataAnnotations;

namespace logReg.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        public string LEmail {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string LPassword {get;set;}
    }
}