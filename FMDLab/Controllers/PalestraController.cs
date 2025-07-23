using FMDLab.Data;
using FMDLab.Models;
using FMDLab.ViewModels;
using FMDLab.ViewModels.Palestras;
using FMDLab.ViewModels.Participantes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace FMDLab.Controllers;

[ApiController]
[Route("api/")]
public class PalestraController : ControllerBase
{
    [SwaggerOperation(Summary = "Retorna todas as palestras disponíveis.")]
    [HttpGet("palestras")]
    public async Task<ActionResult> GetAsync(
        [FromServices] ApplicationDbContext context)
    {
        try
        {
            var palestras = await context.Palestras
                .AsNoTracking()
                .Include(p => p.Participantes)
                .Select(x => new ListPalestrasViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataHora = x.DataHora,
                    Participantes = ListParticipantesViewModel.ConvertAll(x.Participantes)
                })
                .ToListAsync();

            return Ok(new ResultViewModel<IEnumerable<ListPalestrasViewModel>>(palestras));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<IEnumerable<ListPalestrasViewModel>>("Falha interna no servidor."));
        }
    }
    
    [SwaggerOperation(Summary = "Retorna uma palestra a partir de seu ID.")]
    [HttpGet("palestras/{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] ApplicationDbContext context)
    {
        try
        {
            var palestra = await context.Palestras
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (palestra is null)
                return NotFound(new ResultViewModel<Palestra>("Palestra não encontrada."));

            return Ok(new ResultViewModel<Palestra>(palestra));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Palestra>("Falha interna no servidor."));
        }
    }

    [SwaggerOperation(Summary = "Cria uma nova palestra.")]
    [HttpPost("palestras")]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreatePalestraViewModel model,
        [FromServices] ApplicationDbContext context)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var palestra = new Palestra
            {
                Id = Guid.NewGuid(),
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataHora = model.DataHora,
                Participantes = new()
            };
            
            await context.Palestras.AddAsync(palestra);
            await context.SaveChangesAsync();
            
            return Created($"api/palestras/{palestra.Id}", new ResultViewModel<Palestra>(palestra));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Palestra>("Não foi possível criar a palestra."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Palestra>("Falha interna no servidor."));
        }
    }
}