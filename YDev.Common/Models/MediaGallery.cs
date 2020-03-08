using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class MediaGallery : BaseEntity
    {
        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public string MediaUrl { get; set; }
        public bool IsCoverImage { get; set; } = false;
    }
}
