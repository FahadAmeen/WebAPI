using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models.Wrappers
{
    public class FileDownload
    {
        public string fileName { get; set; }
        public string contentType { get; set; }
        public string file { get; set; }

    }
}
