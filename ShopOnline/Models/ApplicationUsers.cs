using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
