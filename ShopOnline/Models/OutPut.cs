using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Output
    {
        public string Id { get; set; }

        [Required]
        [Display(Name ="Ngày xuất")]
        public DateTime DateOutput { get; set; }
    }
}
