using superhero_api.Data;
using superhero_api.Models;

namespace superhero_api.Interfaces;

public interface ISuperheroRepository {
    public Task<Superhero> CreateSuperhero(CreateSuperheroDTO superhero);

    public Task<IList<Superhero>> GetAllSuperheros();

    public Task<Superhero?> GetSuperheroById(int superheroId);

    public Task<Superhero?> UpdateSuperhero(int superheroId, UpdateSuperheroDTO superhero);

    public Task DeleteSuperhero(int superheroId);
}