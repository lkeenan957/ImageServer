using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageServer.Models
{
    public class ModerateImages
    {
        public int? imageid { get; set; }
        public string imagename { get; set; }
        public string imagepath { get; set; }
        public string imagetag { get; set; }
        public int ismoderate { get; set; }
        public int isapproved { get; set; }

    }
}
