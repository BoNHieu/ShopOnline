using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product
    {

        public string Id { get; set; }

        [Required]
        [Display(Name="Tên thiết bị")]
        public string Name { get; set; }

        [Display(Name ="Hình ảnh")]
        public string Image { get; set; }

        [Display(Name="Trạng thái")]
        public string Status { get; set; }

        [Display(Name="Mô tả")]
        public string Descirption { get; set; }

        [Required]
        [Display(Name="Danh mục")]
        public string CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public  ICollection<Category> Categories { get; set; }

    }
}
