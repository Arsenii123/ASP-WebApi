using Films.Models;
using Microsoft.AspNetCore.Mvc;

namespace Films.Services.Interfaces
{
    public interface ICreate
    {
        Task Create([Bind("Name,Director,Genre,Description,Age")] Movie movie, IFormFile? posterFile);


    }
}
