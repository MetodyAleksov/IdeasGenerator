using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdeasGenerator.Data.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ActivityDescription { get; set; }

        [Required]
        public string Type { get; set; }

        public decimal Price { get; set; }
    }
}
