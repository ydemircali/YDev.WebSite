using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class RoleTypes : BaseEntity
    {
        public string RoleName { get; set; }
        public byte Status { get; set; }
    }
}
