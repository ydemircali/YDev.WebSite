using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Title : BaseEntity
    {
        public string TitleName { get; set; }
        public byte Status { get; set; }
    }
}
