using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Input
    {
        public string Id { get; set; }

        [Display(Name ="Tên người nhập")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Ngày nhập")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime DateInput { get; set; }
    }
}
