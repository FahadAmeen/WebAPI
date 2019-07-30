using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class ResetPassword
    {
        [Key]
        public int id { get; set; }
        public string userEmail { get; set; }
        public DateTime resetRequestTime { get; set; }
        public DateTime expiryTime { get; set; }

    }
}
