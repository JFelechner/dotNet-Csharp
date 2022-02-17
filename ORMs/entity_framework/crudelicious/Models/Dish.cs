using System;
using System.ComponentModel.DataAnnotations;

namespace crudelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set;}

        [Required]
        public string NameOfDish { get; set; }

        [Required]
        public string ChefName { get; set; }

        [Required]
        [Range(1,10000, ErrorMessage = "Calories must be greater than 0")]
        public int Calories { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "Tastiness must be between 1 and 5")]
        public int Tastiness { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}