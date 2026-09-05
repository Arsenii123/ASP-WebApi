using Films.Models;
using Films.Repositories.Interfaces;
using Films.Services.Interfaces;

namespace Films.Services
{
    public class EditService : IEdit
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IRepository _repo;

        public EditService(IWebHostEnvironment appEnvironment, IRepository repo)
        {
            _appEnvironment = appEnvironment;
            _repo = repo;
        }

        public async Task Edit(int id, Movie movie, IFormFile? posterFile)
        {
            var movieInDb = await _repo.Get(id);
            if (movieInDb == null)
                return;

            movieInDb.Name = movie.Name;
            movieInDb.Director = movie.Director;
            movieInDb.Genre = movie.Genre;
            movieInDb.Description = movie.Description;
            movieInDb.Age = movie.Age;

            if (posterFile != null && posterFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "img");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueName = Guid.NewGuid() + "_" + Path.GetFileName(posterFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await posterFile.CopyToAsync(stream);
                }

                movieInDb.Poster = new FileModel
                {
                    Name = posterFile.FileName,
                    Path = "/img/" + uniqueName,
                    UploadDate = DateTime.Now
                };
            }

            await _repo.Set(id, movieInDb);
        }
    }
}
