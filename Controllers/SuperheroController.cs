using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using superhero_api.Data;
using superhero_api.Interfaces;
using superhero_api.Models;

namespace superhero_api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class SuperheroController(ILogger<SuperheroController> _logger, ISuperheroRepository _repo): ControllerBase
{
    private readonly ILogger<SuperheroController> _logger = _logger;
    private readonly ISuperheroRepository _repo = _repo;

    [HttpPost(Name = "PostSuperhero")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateSuperheroDTO payload) {
        if (payload is null) {
            return BadRequest();
        }

        SuperheroDTO superhero = (await _repo.CreateSuperhero(payload)).ToDTO();

        return CreatedAtAction(nameof(Get), new { id = superhero.SuperheroId }, superhero);
    }

    [HttpGet(Name = "GetAllSuperheros")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IList<SuperheroDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<SuperheroDTO>>> GetAll() {
        List<SuperheroDTO> superheroes = ((List<Superhero>) await _repo.GetAllSuperheros()).Select(superhero => superhero.ToDTO()).ToList<SuperheroDTO>();
        return Ok(superheroes);
    }

    [HttpGet("{id}", Name = "GetSuperheroById")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SuperheroDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id) {
        SuperheroDTO? superhero = (await _repo.GetSuperheroById(id))?.ToDTO();

        if (superhero is null) {
            return NotFound();
        }

        return Ok(superhero);
    }

    [HttpPut("{id}", Name = "UpdateSuperheroById")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(SuperheroDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateSuperheroDTO payload) {
        if (payload is null) {
            return BadRequest();
        }
        
        Superhero? superhero = await _repo.UpdateSuperhero(id, payload);
        if (superhero is null) {
            return NotFound();
        }

        return Ok(superhero.ToDTO());
    }

    [HttpDelete("{id}", Name = "DeleteSuperheroById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task Delete([FromRoute] int id) {
        await _repo.DeleteSuperhero(id);
    }
}
