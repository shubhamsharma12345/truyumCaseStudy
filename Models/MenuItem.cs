using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Turuyum.Models
{
    public class MenuItem
    {
        [Key]
        [Required(ErrorMessage = "Field is required")]
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public double price { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
ApplyFormatInEditMode = true)]
        [Display(Name = "DateOfLaunch")]
        public DateTime DateOfLaunch { get; set; }

        [Display(Name = "FreeDelivery")]
        public bool freedelivery { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}