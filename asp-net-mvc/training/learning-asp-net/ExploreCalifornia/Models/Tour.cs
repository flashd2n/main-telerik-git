using System;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name="Length in days")]
        [Range(1, 99)]
        public int Length { get; set; }

        public decimal Price { get; set; }

        public string Rating { get; set; }

        [Display(Name = "Includes Meals")]
        public bool IncludesMeals { get; set; }
    }
}