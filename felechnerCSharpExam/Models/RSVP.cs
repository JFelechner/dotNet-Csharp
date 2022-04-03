using System;
using System.ComponentModel.DataAnnotations;

namespace felechnerCSharpExam.Models
{
    public class RSVP
    {
        [Key]
        public int RSVPId {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}

        public int ShinDigId {get;set;}
        public ShinDig ShinDig {get;set;}

    }
}