using System;
using System.Collections.Generic;
using System.Text;
using YDev.Common.Enum;

namespace YDev.Common.Models
{
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Path { get; set; }
        public string ThumbnailPath { get; set; }
        public string Link { get; set; }
        public MediaTypes MediaType { get; set; }

    }
}
