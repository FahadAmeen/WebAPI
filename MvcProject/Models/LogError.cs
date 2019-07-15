using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class LogError
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set;}
        public string Created { get; set; }
    }
}
