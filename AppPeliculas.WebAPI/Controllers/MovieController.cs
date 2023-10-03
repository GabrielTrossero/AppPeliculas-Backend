using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppPeliculas.Model.Services;

namespace AppPeliculas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            if (this.movieService.SearchMovies())
            {
                return Ok(true);
            }
            else return Ok(false);
        }
    }
}
