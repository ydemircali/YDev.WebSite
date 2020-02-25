using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class StaticPages : BaseEntity
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
