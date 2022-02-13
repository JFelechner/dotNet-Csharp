
using System;
using System.ComponentModel.DataAnnotations;

namespace dojo_survey_with_validation
{
    public class User
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string userName {get;set;} //get/set allows communications with MySql
        
        [Required]
        public string userDojoLocation {get;set;}

        [Required]
        public string userFavoriteLanguage {get;set;}

        [MaxLength(20, ErrorMessage ="Comment should be no longer than 20 characters")]
        public string userComment {get;set;}
    }
}