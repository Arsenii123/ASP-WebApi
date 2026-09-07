using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
[HttpGet("/")]
public ContentResult Index()
{
    var html = @"
    <!DOCTYPE html>
    <html>
    <head>
        <title>Films API</title>
        <style>
            body { font-family: Arial; max-width: 600px; margin: 50px auto; padding: 20px; }
            a { color: #0066cc; }
        </style>
        </head>
    <body>
        <h1>Films API</h1>
        <p>API работает!</p>
        <ul>
            <li><a href=""/api/Movies"">Список фильмов</a></li>
            <li><a href=""/swagger"">Swagger</a></li>
        </ul>
    </body>
    </html>";

    return Content(html, "text/html");
}

        /// <summary>
        /// Відображає сторінку політики конфіденційності.
        /// </summary>
        /// <returns>Представлення Privacy.</returns>

    }
}
