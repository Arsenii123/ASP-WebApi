using Films.Models;
using Films.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Films.Repositories
{
    public class CRUDRepository : IRepository
    {
        private readonly MovieContext _context;

        public CRUDRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var movie = await _context.Movies
                .Include(m => m.Poster)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie?> Get(int id)
        {
            return await _context.Movies
                .Include(m => m.Poster)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies
                .Include(m => m.Poster)
                .ToListAsync();
        }

        public async Task Set(int id, Movie movie)
        {
            if (id != movie.Id) return;

            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}
