﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class AccessControl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
    }
}
