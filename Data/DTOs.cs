using System.ComponentModel.DataAnnotations;

namespace superhero_api.Data;

public record SuperheroDTO (
    [Required] int SuperheroId,
    [Required] string SuperheroName,
    string? FirstName,
    string? LastName,
    string? City
);

public record CreateSuperheroDTO (
    [Required] string SuperheroName,
    string? FirstName,
    string? LastName,
    string? City
);

public record UpdateSuperheroDTO (
    [Required] string SuperheroName,
    string? FirstName,
    string? LastName,
    string? City
);