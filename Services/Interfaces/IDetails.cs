using Films.Models;

namespace Films.Services.Interfaces
{
    public interface IDetails
    {
        Task<Movie?> Details(int? id);
        Task<IEnumerable<Movie>> GetAll();
    }
}
