using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models.Data.DTO;
using MovieAPI.Models.Data.Repository;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _db;
        public MovieController(IMovie db)
        {
            _db = db;
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDTO model)
        {
            try
            {
                bool result = await _db.AddMovieAsync(model);
                if (result == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var result = await _db.GetMoviesAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("GetMovie/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var result = await _db.GetMovieByIdAsync(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody] AddMovieDTO model, int id)
        {
            try
            {
                bool result = await _db.UpdateMovieAsync(model, id);
                if (result == true)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest("Failed to update movie");
            }
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                bool result = await _db.DeleteMovieAsync(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest("No movie with this id found");
            }
        }

    }
}