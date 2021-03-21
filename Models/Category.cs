using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Turuyum.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Field is required")]
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Field is required")] 
        public string Name { get; set; }

    }
}