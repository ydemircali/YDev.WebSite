using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Media : BaseEntity
    {
        public string Content { get; set; }
        public string Name { get; set; }
        public long Size { get; set; } = 0;
        public string WidthHeight { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsCoverImage { get; set; } = false;

    }
}
