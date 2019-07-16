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

        public virtual string Id { get; set; }

        [Required]
        [Display(Name="Tên thiết bị")]
        public virtual string Name { get; set; }

        [Display(Name ="Hình ảnh")]
        public string Image { get; set; }

        [Display(Name="Trạng thái")]
        public virtual string Status { get; set; }

        [Display(Name="Mô tả")]
        public virtual string Descirption { get; set; }

        [Required]
        [Display(Name="Danh mục")]
        public virtual string CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
