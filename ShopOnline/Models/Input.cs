using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Input
    {
        public string Id { get; set; }

        [Required]
        [Display(Name ="Ngày nhập")]
        public DateTime DateInput { get; set; }
    }
}
