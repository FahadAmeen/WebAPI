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
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        public string File { get; set; }

        public ToDoItem(string title, bool isComplete,string description, string priority )
        {
            this.Title = title;
            this.IsComplete = isComplete;
            this.Description = description;
            this.Priority = priority;
        }
    }
}
