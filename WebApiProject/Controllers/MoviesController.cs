using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
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