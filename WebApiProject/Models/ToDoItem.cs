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
        //public static long CurrentId = 0;
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        //public ToDoItem(ToDoItem newItem)
        //{
        //    CurrentId += 1;
        //    this.Id = CurrentId;
        //    this.IsComplete = newItem.IsComplete;
        //    this.Name = newItem.Name;
        //}

        //public ToDoItem()
        //{
        //    CurrentId += 1;
        //    this.Id = CurrentId;
        //    this.IsComplete = false;
        //    this.Name = "";
        //}

    }
}
