using Microsoft.EntityFrameworkCore;
using superhero_api.Models;

namespace superhero_api.Data;


public class DataContext(DbContextOptions<DataContext> options) : DbContext(options) {
    public DbSet<Superhero> Superheroes { get; set; }
}