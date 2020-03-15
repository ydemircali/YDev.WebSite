using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class HomeSetting : BaseEntity
    {
        [ForeignKey("Gallery")]
        public long HomeGalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}
