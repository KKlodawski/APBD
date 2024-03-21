using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using System.Threading.Tasks;
using MovieApp.Client.Pages;
using MovieApp.Shared.DTOs;
using MovieApp.Shared.Models;


namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _dbService.GetMovies());
        }

        [HttpGet("single/{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            return Ok(await _dbService.GetMovie(id));
        }

        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> EditMovie(int id, [FromBody] MovieDTO updatedMovie)
        {
            return Ok(await _dbService.EditMovie(id, updatedMovie));
        }

        [HttpDelete("del/{id:int}")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            return Ok(await _dbService.DeleteMovie(id));
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _dbService.GetPersons());
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await _dbService.GetGenres());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMovie([FromBody] MovieAddDto newMovie)
        {
            return Ok(await _dbService.AddMovie(newMovie));
        }
    }
}
