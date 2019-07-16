
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Customer
    {
        public string Id { get; set; }

        [Required]
        [Display(Name ="Tên khách hàng")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Số điện thoại")]
        public string Phone { get; set;}

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }

    }
}
