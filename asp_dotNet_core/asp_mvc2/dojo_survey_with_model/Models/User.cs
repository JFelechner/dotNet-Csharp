
using System;
using System.ComponentModel.DataAnnotations;

namespace dojo_survey_with_model
{
    public class User
    {
        [Required]
        public string userName {get;set;} //get/set allows communications with MySql
        
        [Required]
        public string userDojoLocation {get;set;}

        [Required]
        public string userFavoriteLanguage {get;set;}

        [Required]
        public string userComment {get;set;}
    }
}