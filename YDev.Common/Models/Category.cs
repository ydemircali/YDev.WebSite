using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int MasterCategoryId { get; set; } = 0;

    }
}
