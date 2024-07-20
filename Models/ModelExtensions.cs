using superhero_api.Data;

namespace superhero_api.Models;

public static class ModelExtensions {
    public static SuperheroDTO ToDTO(this Superhero superhero) {
        return new(
            superhero.SuperheroId,
            superhero.SuperheroName,
            superhero.FirstName,
            superhero.LastName,
            superhero.City
        );
    }
}