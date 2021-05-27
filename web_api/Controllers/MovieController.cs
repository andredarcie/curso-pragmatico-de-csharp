using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            try
            {
                var movies = await _context.Movies.ToListAsync();

                if (!movies.Any())
                {
                    return NotFound("Movies not found.");
                }

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            try
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);

                if (movie == null)
                {
                    return NotFound("Movie not found.");
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // POST api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> Post([FromBody] Movie movie)
        {
            try
            {
                var director = await _context.Directors.FirstOrDefaultAsync(director => director.Id == movie.DirectorId);

                if (director == null) {
                    return NotFound("Director not found.");
                }

                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> Put(int id, [FromBody] Movie movie)
        {
            try
            {
                movie.Id = id;
                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
                _context.Remove(movie);
                _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
