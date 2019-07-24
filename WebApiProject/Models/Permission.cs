using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApiProject.Models
{
    public class Permission
    {   [Key]
        public int Id { get; set; } 
        public string Pagename { get; set; }
        public string PageURL { get; set; }
        public bool HasPermission { get; set; }
    }
}
