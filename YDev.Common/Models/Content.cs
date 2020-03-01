﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class Content : BaseEntity
    {
        public string Title { get; set; }
        public string Spot { get; set; }
        public string CoverImage { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
        public string Author { get; set; }

        [ForeignKey("Menu")]
        public long MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}