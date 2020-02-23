using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte Status { get; set; }

        [ForeignKey("RoleTypes")]
        public long RoleId { get; set; }
        public RoleTypes Role { get; set; }

        [ForeignKey("Title")]
        public long TitleId { get; set; }
        public Title Title { get; set; }
    }
}
