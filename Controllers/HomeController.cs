using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "index")]
        public IActionResult Index()
        {
            return Ok();
        }

        /// <summary>
        /// Відображає сторінку політики конфіденційності.
        /// </summary>
        /// <returns>Представлення Privacy.</returns>

    }
}
