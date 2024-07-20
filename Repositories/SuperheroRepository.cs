using Microsoft.EntityFrameworkCore;
using superhero_api.Data;
using superhero_api.Interfaces;
using superhero_api.Models;

namespace superhero_api.Repositories;

public class SuperheroRepository(DataContext context) : ISuperheroRepository
{
    private readonly Guid _instanceeId = Guid.NewGuid();

    private readonly DataContext _context = context;
    public async Task<Superhero> CreateSuperhero(CreateSuperheroDTO superheroDTO)
    {
        Superhero superhero = new(){
            SuperheroName = superheroDTO.SuperheroName,
            FirstName = superheroDTO.FirstName,
            LastName = superheroDTO.LastName,
            City = superheroDTO.City
        };

        _context.Superheroes.Add(superhero);
        await _context.SaveChangesAsync();

        return superhero;
    }

    public async Task<IList<Superhero>> GetAllSuperheros()
    {
        return await _context.Superheroes.ToListAsync<Superhero>();
    }

    public async Task<Superhero?> GetSuperheroById(int superheroId)
    {
        return await _context.Superheroes.FindAsync(superheroId);
    }

    public async Task<Superhero?> UpdateSuperhero(int superheroId, UpdateSuperheroDTO superheroDTO)
    {
        Superhero? superhero = await _context.Superheroes.FindAsync(superheroId);

        if (superhero is null) {
            return null;
        }

        superhero.SuperheroName = superheroDTO.SuperheroName;
        superhero.FirstName = superheroDTO.FirstName ?? superhero.FirstName;
        superhero.LastName = superheroDTO.LastName ?? superhero.LastName;
        superhero.City = superheroDTO.City ?? superhero.City;

        await _context.SaveChangesAsync();

        return superhero;
    }

    public async Task DeleteSuperhero(int superheroId)
    {
        Superhero? superhero = await _context.Superheroes.FindAsync(superheroId);

        if (superhero is not null) {
            _context.Superheroes.Remove(superhero);
            await _context.SaveChangesAsync();
        }
    }
}