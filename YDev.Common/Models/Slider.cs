using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class Slider : BaseEntity
    {
        [ForeignKey("Media")]
        public long MediaId { get; set; }
        public Media Media { get; set; }
        /// <summary>
        /// sırası
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// ms cinsinden
        /// </summary>
        public long Time { get; set; }

    }
}
