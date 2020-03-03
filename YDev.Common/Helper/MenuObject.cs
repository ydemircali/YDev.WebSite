using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YDev.Common.Helper
{
    public class MenuObject
    {
        public int Id { get; set; }
        public List<MenuObject> Children { get; set; }
    }
}
