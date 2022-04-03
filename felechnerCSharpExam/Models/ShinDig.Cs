
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace felechnerCSharpExam.Models
{
    public class ShinDig
    {

        public class DateValidator : ValidationAttribute
        {
            public override bool IsValid(object requestedDate)
            {
                DateTime date = (DateTime)requestedDate;
                return date > DateTime.Now;
            }
        }

        [Key]
        public int ShinDigId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateValidator]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public int DurationInt { get; set; }

        [Required]
        public string DurationStr { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User Planner { get; set; } //navigation property needed

        public List<RSVP> Attendees { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}