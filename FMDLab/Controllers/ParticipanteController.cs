using FMDLab.Data;
using FMDLab.Models;
using FMDLab.ViewModels;
using FMDLab.ViewModels.Palestras;
using FMDLab.ViewModels.Participantes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMDLab.Controllers;

[ApiController]
[Route("api/")]
public class ParticipanteController : ControllerBase
{
    [HttpGet("participantes")]
    public async Task<ActionResult> GetAsync(
        [FromServices] ApplicationDbContext context)
    {
        try
        {
            var participantes = await context.Participantes
                .AsNoTracking()
                .Select(x => new ListParticipantesViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Telefone = x.Telefone,
                    PalestraId = x.PalestraId
                })
                .ToListAsync();

            return Ok(new ResultViewModel<IEnumerable<ListParticipantesViewModel>>(participantes));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<IEnumerable<ListParticipantesViewModel>>("Falha interna no servidor."));
        }
    }
    
    [HttpGet("participantes/{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        [FromServices] ApplicationDbContext context)
    {
        try
        {
            var participante = await context.Participantes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (participante is null)
                return NotFound(new ResultViewModel<Participante>("Participante não encontrado."));

            return Ok(new ResultViewModel<Participante>(participante));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Participante>("Falha interna no servidor."));
        }
    }
    
    [HttpPost("participantes")]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateParticipanteViewModel model,
        [FromServices] ApplicationDbContext context)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var palestra = await context.Palestras
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == model.PalestraId);
            
            if (palestra is null)
                return NotFound(new ResultViewModel<Participante>("Palestra não encontrada."));
            
            var participante = new Participante
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                PalestraId = model.PalestraId
            };
            
            await context.Participantes.AddAsync(participante);
            await context.SaveChangesAsync();
            
            return Created($"api/participantes/{participante.Id}", new ResultViewModel<Participante>(participante));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Participante>("Não foi possível criar o participante."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Participante>("Falha interna no servidor."));
        }
    }

    [HttpPut("participantes/{id:guid}")]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] Guid id,
        [FromBody] UpdateParticipanteViewModel model,
        [FromServices] ApplicationDbContext context)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var participante = await context.Participantes.FirstOrDefaultAsync(x => x.Id == id);

            if (participante is null)
                return NotFound(new ResultViewModel<Participante>("Participante não encontrado."));
            
            participante.Nome = model.Nome;
            participante.Email = model.Email;
            participante.Telefone = model.Telefone;
            
            context.Participantes.Update(participante);
            await context.SaveChangesAsync();
            
            return Ok(new ResultViewModel<Participante>(participante));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Participante>("Não foi possível atualizar o participante."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Participante>("Falha interna no servidor."));
        }
    }
    
    [HttpDelete("participantes/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] Guid id,
        [FromServices] ApplicationDbContext context)
    {
        try
        {
            var participante = await context.Participantes.FirstOrDefaultAsync(x => x.Id == id);

            if (participante is null)
                return NotFound(new ResultViewModel<Participante>("Participante não encontrado."));
            
            context.Participantes.Remove(participante);
            await context.SaveChangesAsync();
            
            return Ok(new ResultViewModel<Participante>(participante));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Participante>("Não foi possível atualizar o participante."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Participante>("Falha interna no servidor."));
        }
    }
}