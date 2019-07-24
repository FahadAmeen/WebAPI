using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Context
{
    public class Permission
    {
        [Key]
        public int serial { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public Boolean access { get; set; }
    }
}
