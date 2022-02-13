
using System;
using System.ComponentModel.DataAnnotations;

namespace dojo_survey_with_model
{
    public class User
    {
        public string userName {get;set;} //get/set allows communications with MySql
        
        public string userDojoLocation {get;set;}

        public string userFavoriteLanguage {get;set;}

        public string userComment {get;set;}
    }
}