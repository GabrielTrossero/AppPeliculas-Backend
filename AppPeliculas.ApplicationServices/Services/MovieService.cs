using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPeliculas.Model.Interfaces;
using AppPeliculas.Model.Services;

namespace AppPeliculas.ApplicationServices.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        
        public bool SearchMovies()
        {
            if (this.movieRepository.GetMovies())
            {
                return true;
            }
            else return false;
        }
    }
}
