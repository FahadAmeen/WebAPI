using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models.Wrappers
{
    public class MovieInfoWrapper
    {
        public int count { get; set; }
        public List<Movie> data { get; set; }
    }
}