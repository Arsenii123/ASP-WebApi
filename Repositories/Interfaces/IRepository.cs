using Films.Models;

namespace Films.Repositories.Interfaces
{
    public interface IRepository
    {
        Task Create(Movie movie);
        Task Delete(int? id);
        Task<Movie?> Get(int id);
        Task<IEnumerable<Movie>> GetAll();
        Task Set(int id, Movie movie);
    }
}
