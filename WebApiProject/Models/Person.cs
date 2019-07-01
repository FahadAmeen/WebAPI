using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApiProject.Models
{
    public class Person
    {
        [Key]
        public string Name { get; set; }
    }
}
