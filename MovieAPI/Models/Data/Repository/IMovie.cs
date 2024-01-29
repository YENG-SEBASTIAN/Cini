using MovieAPI.Models.Data.DTO;

namespace MovieAPI.Models.Data.Repository
{
    public interface IMovie
    {
        Task<bool> AddMovieAsync(AddMovieDTO model);
        Task<bool> UpdateMovieAsync(AddMovieDTO model, int id);
        Task<List<MovieDTO>> GetMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task<bool> DeleteMovieAsync(int id);

    }
}