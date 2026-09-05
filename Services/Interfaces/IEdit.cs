using Films.Models;

namespace Films.Services.Interfaces
{
    public interface IEdit
    {
        Task Edit(int id, Movie movie, IFormFile? posterFile);

    }
}
