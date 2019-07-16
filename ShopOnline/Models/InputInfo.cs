using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class InputInfo
    {
        public string Id { get; set; }

        public string InputId { get; set; }

        [ForeignKey("InputId")]
        public virtual Input Input { get; set; }

        [Required]
        [Display(Name ="Tên sản phẩm")]
        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Display(Name ="Nhà cung cấp")]
        public string SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [Required]
        [Display(Name ="Số lượng")]
        public int Count { get; set; }

        [Required]
        [Display(Name ="Giá Nhập")]
        public decimal Inputprice { get; set; }

        [Required]
        [Display(Name ="Giá Xuất")]
        public decimal OutputPrice { get; set; }
    }
}
