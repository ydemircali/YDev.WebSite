using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public byte Status { get; set; } = 1;
        public int Order { get; set; }
    }
}
