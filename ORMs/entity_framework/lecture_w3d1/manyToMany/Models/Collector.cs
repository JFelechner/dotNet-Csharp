using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace manyToMany.Models
{
    public class Collector
    {
        [Key]
        public int CollectorId {get;set;}

        [Required]
        public string Name {get;set;}

        public DateTime CreatedAt {get;set;}  = DateTime.Now;
        public DateTime UpdatedAt {get;set;}  = DateTime.Now;

        public List<Collection> MyCollection {get;set;}

    }
}