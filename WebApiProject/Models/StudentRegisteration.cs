using System;
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

        //const int maxPageSize = 3;

        //public int pageNumber { get; set; } = 1;

        //public int _pageSize { get; set; } = 5;

        //public int pageSize
        //{

        //    get { return _pageSize; }
        //    set
        //    {
        //        _pageSize = (value > maxPageSize) ? maxPageSize : value;
        //    }
        //}
    }
}
