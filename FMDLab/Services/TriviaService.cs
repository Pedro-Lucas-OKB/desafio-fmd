using System.Net;
using FMDLab.Interfaces;
using FMDLab.Models;

namespace FMDLab.Services;

public class TriviaService : ITriviaService
{
    private readonly HttpClient _httpClient;
    
    public TriviaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(string pergunta, string resposta)?> GetTriviaAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<TriviaResponse>("https://opentdb.com/api.php?amount=1");
        
        var result = response?.Results?.FirstOrDefault();

        if (result is null)
            throw new Exception("Não foi possível obter o Trivia.");
        
        var pergunta = WebUtility.HtmlDecode(result.Question);
        var resposta = WebUtility.HtmlDecode(result.CorrectAnswer);
        
        return (pergunta, resposta);
    }
}