using Films.Models;
using Films.Repositories.Interfaces;
using Films.Services.Interfaces;

namespace Films.Services
{
    public class DetailsService : IDetails
    {
        private readonly IRepository _repository;

        public DetailsService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Movie?> Details(int? id)
        {
            if (id == null) return null;
            return await _repository.Get(id.Value);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
