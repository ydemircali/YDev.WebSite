﻿namespace YDev.Admin.Models
{
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public long Size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
        public string widthHeight { get; set; }
    }
}
