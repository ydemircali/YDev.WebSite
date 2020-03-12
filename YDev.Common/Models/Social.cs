using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Social : BaseEntity
    {
        public string SocialName { get; set; }
        public string Url { get; set; }
        public string Account { get; set; }
    }
}
