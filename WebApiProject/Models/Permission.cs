using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageUrl { get; set; }
        public bool isAccessible { get; set; }

        public Permission()
        {

        }

        public Permission(string pageurl, bool pageIsAccessible)
        {
            this.PageUrl = pageurl;
            this.isAccessible = pageIsAccessible;
        }
    }
}
