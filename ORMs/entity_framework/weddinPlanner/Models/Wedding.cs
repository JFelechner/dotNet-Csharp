
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace weddinPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required]
        public string WedderOne {get;set;}
        [Required]
        public string WedderTwo {get;set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date {get;set;}

        [Required]
        public string Address {get;set;}

        public int UserId {get;set;}

        public User Planner {get;set;} //navigation property needed

        public List<RSVP> Guests {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateddAt {get;set;} = DateTime.Now;
    }
}