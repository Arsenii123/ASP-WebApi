using Films.Models;
using Films.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Films.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {
        private readonly ICreate _createService;
        private readonly IEdit _editService;
        private readonly IDelete _deleteService;
        private readonly IDetails _detailsService;

        public MovieController(
            ICreate createService,
            IEdit editService,
            IDelete deleteService,
            IDetails detailsService)
        {
            _createService = createService;
            _editService = editService;
            _deleteService = deleteService;
            _detailsService = detailsService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var movies = await _detailsService.GetAll();
            return Ok(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            var movie = await _detailsService.Details(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> Create(
            [FromForm] Movie movie,
            IFormFile? posterFile)
        {
            if (posterFile == null || posterFile.Length == 0)
                ModelState.AddModelError("Poster", "Будь ласка, виберіть файл постера");

            if (!string.IsNullOrEmpty(movie.Name) && movie.Name == movie.Director)
                ModelState.AddModelError("", "Назва фільму і режисер не можуть збігатися");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _createService.Create(movie, posterFile);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Movies/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(
            int id,
            [FromForm] Movie movie,
            IFormFile? posterFile)
        {
            if (id != movie.Id)
                return BadRequest("Id в URL і в тілі запиту не збігаються");

            var existing = await _detailsService.Details(id);
            if (existing == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _editService.Edit(id, movie, posterFile);
            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _detailsService.Details(id);
            if (existing == null)
                return NotFound();

            await _deleteService.Delete(id);
            return NoContent();
        }
    }
}
