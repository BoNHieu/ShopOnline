using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Supplier
    {
        public string Id { get; set; }

        [Required]
        [Display(Name="Tên nhà cung cấp")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Số điện thoại ")]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name="Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [Display(Name="Mô tả")]
        public string Description { get; set; }

        [Display(Name="Ngày hợp tác")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime ContractDate { get; set; }
    }
}
