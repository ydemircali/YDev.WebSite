using System;
using System.Collections.Generic;
using System.Text;

namespace YDev.Common.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public byte ContactType { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string MapUrl { get; set; }
    }
}
