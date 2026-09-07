
using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public ContentResult Index()
        {
            var html = @"<!DOCTYPE html>
<html lang=""uk"">
<head>
    <meta charset=""utf-8"">
    <title>Films API</title>
    <style>
        body { font-family: Arial, sans-serif; max-width: 600px; margin: 50px auto; padding: 20px; }
        a { color: #0066cc; text-decoration: none; }
        a:hover { text-decoration: underline; }
        ul { line-height: 1.8; }
    </style>
</head>
<body>
    <h1>Films API</h1>
    <p>API працює!</p>
    <ul>
        <li><a href=""/api/Movies"">Список фільмів</a></li>
        <li><a href=""/swagger"">Swagger</a></li>
    </ul>
</body>
</html>";

            return Content(html, "text/html; charset=utf-8");
        }
    }
}

