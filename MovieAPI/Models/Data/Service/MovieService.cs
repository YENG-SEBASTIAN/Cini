using Microsoft.EntityFrameworkCore;
using MovieAPI.Models.Data.DTO;
using MovieAPI.Models.Data.Repository;

namespace MovieAPI.Models.Data.Service
{
    public class MovieService : IMovie
    {
        private readonly CiniMoviesContext _db;
        public MovieService(CiniMoviesContext db){
            _db = db;
        }

        public async Task<bool> AddMovieAsync(AddMovieDTO model)
        {
            CiniMovie ciniMovie = new(){
                Title = model.Title,
                Genre = model.Genre,
                ReleaseYear = model.ReleaseYear
            };
            await _db.CiniMovies.AddAsync(ciniMovie);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            CiniMovie ciniMovie = await _db.CiniMovies
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            if(ciniMovie == null){
                return false;
            }

            _db.CiniMovies.Remove(ciniMovie);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            CiniMovie ciniMovie = await _db.CiniMovies
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            if(ciniMovie == null){
                return new MovieDTO();
            }

            MovieDTO movie = new(){
                Id = ciniMovie.Id,
                Title = ciniMovie.Title,
                Genre = ciniMovie.Genre,
                ReleaseYear = ciniMovie.ReleaseYear
            };

            return movie;
        }

        public async Task<List<MovieDTO>> GetMoviesAsync()
        {
            List<CiniMovie> ciniMovies = await _db.CiniMovies.ToListAsync();
            if(ciniMovies == null){
                return new List<MovieDTO>();
            }

            List<MovieDTO> movieDTOs = ciniMovies.Select(x => new MovieDTO{
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                ReleaseYear = x.ReleaseYear
            }).ToList();

            return movieDTOs;
        }

        public async Task<bool> UpdateMovieAsync(AddMovieDTO model, int id)
        {
            CiniMovie ciniMovie = await _db.CiniMovies
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            if(ciniMovie == null){
                return false;
            }

            ciniMovie.Title = model.Title;
            ciniMovie.Genre = model.Genre;
            ciniMovie.ReleaseYear = model.ReleaseYear;

            _db.CiniMovies.Update(ciniMovie);
            await _db.SaveChangesAsync();

            return true;

        }
    }
}