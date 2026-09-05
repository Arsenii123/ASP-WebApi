using Films.Models;
using Films.Repositories.Interfaces;
using Films.Services.Interfaces;

namespace Films.Services
{
    public class CreateService : ICreate
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IRepository _repo;

        public CreateService(IWebHostEnvironment appEnvironment, IRepository repo)
        {
            _appEnvironment = appEnvironment;
            _repo = repo;
        }

        public async Task<Movie> Create(Movie movie, IFormFile? posterFile)
        {
            if (posterFile == null || posterFile.Length == 0)
                throw new ArgumentException("Файл постера обов'язковий");

            var uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "img");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueName = Guid.NewGuid() + "_" + Path.GetFileName(posterFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await posterFile.CopyToAsync(stream);
            }

            movie.Poster = new FileModel
            {
                Name = posterFile.FileName,
                Path = "/img/" + uniqueName,
                UploadDate = DateTime.Now
            };

            await _repo.Create(movie);
            return movie;
        }
    }
}
