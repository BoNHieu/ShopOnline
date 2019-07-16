using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Category
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Tên danh mục")]
        public virtual string Name { get; set; }

    }
}
