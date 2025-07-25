using FMDLab.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FMDLab.Controllers;

[ApiController]
[Route("api/trivia")]
public class TriviaController : ControllerBase
{
    private readonly ITriviaService _triviaService;

    public TriviaController(ITriviaService triviaService)
    {
        _triviaService = triviaService;
    }

    [SwaggerOperation(Summary = "Retorna uma pergunta e uma resposta do Trivia.")]
    [HttpGet("")]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var trivia = await _triviaService.GetTriviaAsync();
            return Ok(new {trivia.Value.pergunta, trivia.Value.resposta});
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}