using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;
using WebApiProject.Models.Wrappers;
using static System.Net.Mime.MediaTypeNames;

namespace WebApiProject.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MoviesController : ControllerBase
    {
        private readonly DBContext _context;

        public MoviesController(DBContext context)
        {
            _context = context;
        }

        //api/UserModel?page=3&limit=8&sort=Id
        [HttpGet]
        public async Task<IList<Movie>> GetMovies(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "", string type = "json")
        {
            var _page = page;
            var _limit = limit;
            var _sort = sort;
            var _search = search;
            var _type = type;
            switch (type)
            {
                case ("json"):
                    Request.Headers["Accept"] = "application/json";
                    return await Get(_page, _limit, _sort, _search, _type = "json");
                case ("xml"):
                    Request.Headers["Accept"] = "application/xml";
                    return await Get(_page, _limit, _sort, _search, _type = "xml");
                default:
                    return await Get();
            }

        }

        [HttpGet("allData")]
        public MovieInfoWrapper CountAndData()
        {
            //int count = _context.UserModels.Count();
            MovieInfoWrapper movies = new MovieInfoWrapper();
            movies.count = _context.Movies.Count();
            movies.data = _context.Movies.ToList();
            return movies;
        }
        


        [HttpGet("count")]
        public int TotalRecords()
        {

            return _context.Movies.Count();
        }

        public async Task<IList<Movie>> Get(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "", string type = "json")
        {
            var skip = (page - 1) * limit;
            if (search == "")
            {
                var movies = _context.Movies.OrderBy(p => EF.Property<object>(p, sort));

                return await movies.Skip(skip).Take(limit).ToArrayAsync();
            }
            else
            {
                var movies = _context.Movies.Where(p => p.Id.ToString().Contains(search) || p.Title.Contains(search) || p.Director.Contains(search) || p.Genre.Contains(search) || p.ReleaseDate.Contains(search) || p.Description.Contains(search)).OrderBy(p => EF.Property<object>(p, sort)); //True version

                return await movies.Skip(skip).Take(limit).ToArrayAsync();
            }
        }
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string poster = movie.Poster;
            int pos = poster.IndexOf(',')+1;
            int pos2 = poster.IndexOf('$');
            string fileName = poster.Substring(0, pos2);
            string base64 = poster.Remove(0, pos);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            byte[] imageBytes = Convert.FromBase64String(base64);
            movie.Poster = filePath;

            System.IO.File.WriteAllBytes(filePath, imageBytes);
        
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }
        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download([FromRoute] int id)
        {
            
            var movie = await _context.Movies.FindAsync(id);
            string fileName = "";
            string contentType = "";
            string myFilePath = "";
            if (movie != null)
            {
                // found it
                myFilePath = movie.Poster;
                fileName = Path.GetFileNameWithoutExtension(myFilePath);
                contentType = Path.GetExtension(myFilePath);
                Byte[] byteArray = System.IO.File.ReadAllBytes(myFilePath.ToString());
                var file = Convert.ToBase64String(byteArray);
                return Ok(new FileDownload {file=file, contentType=contentType,fileName=fileName });
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}