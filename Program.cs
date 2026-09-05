
using Films.Models;
using Films.Repositories;
using Films.Repositories.Interfaces;
using Films.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Films
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connection));
            // ApplicationContext больше не регистрируем


            builder.Services.AddServices();
            builder.Services.AddTransient<IRepository, CRUDRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer(); // сканує ендпоінти для генерації OpenAPI-документу
            builder.Services.AddSwaggerGen(); // генерує OpenAPI-документ на основі відсканованих ендпоінтів

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger(); // генерує /swagger/v1/swagger.json
                app.UseSwaggerUI(); // UI на /swagger
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
