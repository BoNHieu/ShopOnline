using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class OutputInfo
    {
        public string Id { get; set; }

        public string OuputId { get; set; }

        public virtual Output Output { get; set; }

        public string InputInfoId { get; set; }

        public virtual InputInfo InputInfo { get; set; }

        [Required]
        [Display(Name ="Số lượng")]
        public int Count { get; set; }

        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public string Status { get; set; }
    }
}
