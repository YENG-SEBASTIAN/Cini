using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDTO model){
            try
            {
                bool result = await _db.AddMovieAsync(model);
                if(result == true){
                    return Ok();
                }
                return BadRequest();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }
    }
}