using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Models.ViewModel
{
    public class InputViewModel
    {
        public Input Input { get; set; }
        
        public ICollection<InputInfo> inputInfos { get; set; }
    }
}
