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

        [ForeignKey("Media")]
        public long MediaId { get; set; }
        public Media Media { get; set; }
    }
}
