using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class Movie
    {   [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
    }
}
