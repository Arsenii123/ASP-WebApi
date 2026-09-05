using Films.Repositories.Interfaces;
using Films.Services.Interfaces;

namespace Films.Services
{
    public class DeleteService : IDelete
    {
        public Guid Id { get; } = Guid.NewGuid();
        private IRepository _repo;
        public DeleteService(IRepository repo)
        {
            _repo = repo;
        }
        public async Task Delete(int? id)
        {
            await _repo.Delete(id);
        }
    }
}
