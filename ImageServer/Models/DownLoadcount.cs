using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageServer.Models
{
    public class DownLoadcount
    {
        public int downloadcount { get; set; }
        public int? imageid { get; set; }
        public string imagename { get; set; }
        public string imagepath { get; set; }
        // it can be nullable
    }
}