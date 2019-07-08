//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApiProject.Data;
//using WebApiProject.Models;

//namespace WebApiProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MoviesController : ControllerBase
//    {
//        private readonly DBContext _context;

//        public MoviesController(DBContext context)
//        {
//            _context = context;
//        }
//        //api/Movies?page=3&limit=8&sort=Director
//        [HttpGet]
//        public async Task<IList<Movie>> GetMovies(int page=1, int limit=int.MaxValue, string sort="Id")
//        {
//            var skip = (page - 1) * limit;

//            //if (sort.Equals("Id") || sort.Equals("Title") || sort.Equals("Director") || sort.Equals("Genre") || sort.Equals("ReleaseDate") || sort.Equals("Description") || sort.Equals("Poster"))
//            //{
//                var movies = _context.Movies.OrderBy(p => EF.Property<object>(p, sort));

//                return await movies.Skip(skip).Take(limit).ToArrayAsync();

//            //}
//        }

//        // GET: api/Movies/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetMovie([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var movie = await _context.Movies.FindAsync(id);

//            if (movie == null)
//            {
//                return NotFound();
//            }

//            return Ok(movie);
//        }
        

//        // PUT: api/Movies/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutMovie([FromRoute] int id, [FromBody] Movie movie)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != movie.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(movie).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!MovieExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Movies
//        [HttpPost]
//        public async Task<IActionResult> PostMovie([FromBody] Movie movie)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Movies.Add(movie);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
//        }

//        // DELETE: api/Movies/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var movie = await _context.Movies.FindAsync(id);
//            if (movie == null)
//            {
//                return NotFound();
//            }

//            _context.Movies.Remove(movie);
//            await _context.SaveChangesAsync();

//            return Ok(movie);
//        }

//        private bool MovieExists(int id)
//        {
//            return _context.Movies.Any(e => e.Id == id);
//        }
//    }
//}