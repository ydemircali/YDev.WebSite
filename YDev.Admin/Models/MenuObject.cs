using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YDev.Admin.Models
{
    public class MenuObject
    {
        public int Id { get; set; }
        public List<MenuObject> Children { get; set; }
    }
}
