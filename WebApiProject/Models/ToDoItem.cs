using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class ToDoItem
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        public string File { get; set; }
    }
}
