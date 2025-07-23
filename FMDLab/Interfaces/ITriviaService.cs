namespace FMDLab.Interfaces;

public interface ITriviaService
{
    public Task<(string pergunta, string resposta)?> GetTriviaAsync();
}