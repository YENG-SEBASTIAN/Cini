using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Models.Data.MovieDTO;

namespace MovieAPI.Models.Data.Repository;
public interface IMovie
{
    Task<bool> AddMovies(AddMovieDTO model);
    Task<List<MovieDTO>> GetMovies();
    Task<MovieDTO> GetMovieById(int id);
    Task<bool> UpdateMovie(AddMovieDTO model);
    Task<bool> DeleteMovie(int id);
}