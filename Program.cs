using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using superhero_api.Data;
using superhero_api.Interfaces;
using superhero_api.Repositories;

namespace superhero_api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHttpLogging(logging => {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.RequestHeaders.Add("Referer");
            logging.ResponseHeaders.Add("MyResponseHeader");
        });
        // Add services to the container.

        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<DataContext>(options => {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        //Scoped Services
        builder.Services.AddScoped<ISuperheroRepository, SuperheroRepository>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpLogging();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
