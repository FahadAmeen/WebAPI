﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class StudentRegisteration
    {   [Key]
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Program { get; set; }

        public string Detail { get; set; }
        public string Filename { get; set; }


    }
}
