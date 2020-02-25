using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? RecordDate { get; set; }
        public long? RecordUser { get; set; }
    }
}
