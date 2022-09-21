using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdeasGenerator.Data.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
