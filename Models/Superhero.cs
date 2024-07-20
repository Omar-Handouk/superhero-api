using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace superhero_api.Models;

[Table("Superheros")]
public class Superhero {
    
    [Key]
    [Column("superhero_id")]
    public int SuperheroId { get; set; }
    
    [Required]
    [Column("superhero_name")]
    public required string SuperheroName { get; set; }
    
    [Column("firstname")]
    public string? FirstName { get; set; } = string.Empty;
    
    [Column("lastname")]
    public string? LastName { get; set; } = string.Empty;

    [Column("city")]
    public string? City { get; set; } = string.Empty;
}