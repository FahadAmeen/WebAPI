using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.ErrorLog
{
    public class LoggingError
    {
        [Key]
        public int Id { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Created { get; set; }
    }
}
