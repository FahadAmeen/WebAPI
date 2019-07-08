using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }

    }
}
