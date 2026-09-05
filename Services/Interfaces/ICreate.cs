using Films.Models;

namespace Films.Services.Interfaces
{
    public interface ICreate
    {
        Task<Movie> Create(Movie movie, IFormFile? posterFile);
    }
}
