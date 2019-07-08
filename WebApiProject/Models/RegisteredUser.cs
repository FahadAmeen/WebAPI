using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email_address { get; set; }
        public string Phone_number { get; set; }
        public string Job_type { get; set; }
        public string Password { get; set; }
        public string FileName { get; set; }

       
    }
}
