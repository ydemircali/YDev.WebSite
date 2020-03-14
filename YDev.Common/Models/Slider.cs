using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YDev.Common.Models
{
    public class Slider : BaseEntity
    {
        /// <summary>
        /// sırası
        /// </summary>
        public int Order { get; set; } = 1;
        /// <summary>
        /// ms cinsinden
        /// </summary>
        public long Time { get; set; } = 500;
        /// <summary>
        /// açıkla
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// image url
        /// </summary>
        public string MediaUrl { get; set; }

        public string TinyMediaUrl { get; set; }
        /// <summary>
        /// slider click event
        /// </summary>
        public string Link { get; set; }

    }
}
